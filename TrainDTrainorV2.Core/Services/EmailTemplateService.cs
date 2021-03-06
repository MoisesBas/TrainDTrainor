﻿using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using HandlebarsDotNet;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;

namespace TrainDTrainorV2.Core.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMemoryCache _cache;

        public EmailTemplateService(TrainDTrainorContext dataContext, IMemoryCache cache)
        {
            _dataContext = dataContext;
            _cache = cache;
        }


        public async Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword)
        {
            var emailTemplate = await GetEmailTemplate(Templates.ResetPassword).ConfigureAwait(false);

            var subjectTemplate = Handlebars.Compile(emailTemplate.Subject);
            var htmlBodyTemplate = Handlebars.Compile(emailTemplate.HtmlBody);
            var textBodyTemplate = Handlebars.Compile(emailTemplate.TextBody);

            var subject = subjectTemplate(resetPassword);
            var htmlBody = htmlBodyTemplate(resetPassword);
            var textBody = textBodyTemplate(resetPassword);

            var message = new MimeMessage();
            message.Headers.Add("X-Mailer-Machine", Environment.MachineName);
            message.Headers.Add("X-Mailer-Date", DateTime.Now.ToString(CultureInfo.InvariantCulture));

            message.Subject = subject;

            message.From.Add(new MailboxAddress(emailTemplate.FromName, emailTemplate.FromAddress));

            if (emailTemplate.ReplyToAddress.HasValue())
                message.ReplyTo.Add(new MailboxAddress(emailTemplate.ReplyToName, emailTemplate.ReplyToAddress));

            message.To.Add(new MailboxAddress(resetPassword.DisplayName, resetPassword.EmailAddress));

            var builder = new BodyBuilder
            {
                TextBody = textBody,
                HtmlBody = htmlBody
            };

            message.Body = builder.ToMessageBody();

            await WriteEmailDelivery(message).ConfigureAwait(false);

            return true;
        }


        private async Task WriteEmailDelivery(MimeMessage message)
        {
            var emailDelivery = new EmailDelivery();
            emailDelivery.From = message.From.ToDelimitedString(";").Truncate(256);
            emailDelivery.To = message.To.ToDelimitedString(";").Truncate(256);
            emailDelivery.Subject = message.Subject.Truncate(256);

            using (var memoryStream = new MemoryStream())
            {
                await message.WriteToAsync(memoryStream).ConfigureAwait(false);
                emailDelivery.MimeMessage = memoryStream.ToArray();
            }

            await _dataContext.EmailDeliveries.AddAsync(emailDelivery).ConfigureAwait(false);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task<EmailTemplate> GetEmailTemplate(string templateKey)
        {
            var cacheKey = "data-" + templateKey;
            var emailTemplate = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.Priority = CacheItemPriority.NeverRemove;

                var template = await _dataContext.EmailTemplates
                    .AsNoTracking()
                    .GetByKeyMemberAsync(templateKey)
                    .ConfigureAwait(false);

                return template;
            }).ConfigureAwait(false);

            if (emailTemplate == null)
                throw new DomainException(500, $"Could not find email template for key '{templateKey}'.");

            return emailTemplate;
        }

        public static class Templates
        {
            public const string ResetPassword = "reset-password";
        }
    }
}
