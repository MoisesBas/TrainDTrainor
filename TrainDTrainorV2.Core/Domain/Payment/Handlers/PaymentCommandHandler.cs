using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class PaymentCommandHandler : RequestHandlerBase<PaymentCommand, PaymentReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ISMSTemplateService _sMSTemplateService;
        private readonly IOptions<SMSConfiguration> _smsConfiguration;
        public PaymentCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            ISMSTemplateService sMSTemplateService,
            IOptions<SMSConfiguration> smsConfiguration) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _sMSTemplateService = sMSTemplateService;
            _smsConfiguration = smsConfiguration;
        }

        protected override async Task<PaymentReadModel> ProcessAsync(PaymentCommand message, CancellationToken cancellationToken)
        {
            CreateResult result = new CreateResult();
            if (message.Payment.UserProfileId == null) throw new DomainException(422, $"User Profile  Id is null , Please try again.");
            var current = _dataContext.PaymentTransactions
                                .GetByUserProfileId(message.Payment.UserProfileId.Value).Result;
            if(!message.Payment.CourseId.HasValue)
                throw new DomainException(422, $"Course is required for training registration and payments.");

            var course = _dataContext.TrainingCourse.GetByKey(message.Payment.CourseId.Value);

            if(course == null)
                throw new DomainException(422, $"Course is not exists.");
            if (course.NoAttendee == course.MaxAttendee)
                throw new DomainException(422, $"Course is already full., Please select other course or contact System Administrator.");

            if (current != null)  throw new DomainException(422, $"You already register to training, Please contact System Administrator.");
            current = current == null ? _mapper.Map<Data.Entities.PaymentTransaction>(message.Payment) :
                _mapper.Map(message.Payment, current);

           
            result = _mapper.Map<CreateResult>(_dataContext.FindFolder(new PaymentTransactionPic() { Name = typeof(PaymentTransactionPic).Name}));
            if (result == null) result = _dataContext.CreateDir(new PaymentTransactionPic() { Name = typeof(PaymentTransactionPic).Name, ParentPath = null });
            if (message.Payment.File != null)
            {
                if (message.Payment.File.Length > 0)
                {
                    var file = message.Payment.File;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var now = DateTimeOffset.Now;
                        var payment = new PaymentTransactionPic()
                        {
                            Name = Guid.NewGuid() + "_" + message.Payment.File.FileName,
                            File_stream = ms.ToArray(),
                            ParentPath = result.Path,
                            Creation_time = now,
                            Last_access_time = now,
                            Last_write_time = now,
                            Stream_id = current.FileId ?? Guid.NewGuid()
                        };

                        result = _dataContext.CreateFile(payment);
                    }
                    _mapper.Map(result, current);
                }
            }
            if (result != null)
            {
                if (current.Id == Guid.Empty)
                {
                    var dbSet = _dataContext.Set<Data.Entities.PaymentTransaction>();
                    await dbSet
                        .AddAsync(current, cancellationToken)
                        .ConfigureAwait(false);
                }
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (status != 0)
                {
                    var msg = string.Format(@"Request for TOT payment approval. Id: {0}",current.Id);
                   await _sMSTemplateService.ForApproval(_smsConfiguration.Value.Admin, msg)
                                            .ConfigureAwait(false);

                    var history = _mapper.Map<Data.Entities.PaymentTransactionHistory>(current);
                    var dbSetHistory = _dataContext.Set<Data.Entities.PaymentTransactionHistory>();
                    await dbSetHistory.AddAsync(history, cancellationToken).ConfigureAwait(false);
                    await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    return _mapper.Map<PaymentReadModel>(current);
                }
                else
                {
                    Logger.LogWarning($"Unable to update user your payment, please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to update user your payment, please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to update user your payment, please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to update user your payment, please try again later or contact administrator.");
            }
        }


    }
}
