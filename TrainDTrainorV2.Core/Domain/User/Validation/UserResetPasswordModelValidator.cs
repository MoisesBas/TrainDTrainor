using System;
using FluentValidation;
using TrainDTrainorV2.Core.Domain.Models;


namespace TrainDTrainorV2.Core.Domain.Validation
{
    public class UserResetPasswordModelValidator : AbstractValidator<UserResetPasswordModel>
    {
        public UserResetPasswordModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);

            RuleFor(p => p.ResetToken).NotEmpty();

            RuleFor(p => p.UpdatedPassword).NotEmpty();
            RuleFor(p => p.UpdatedPassword).MinimumLength(8);
        }
    }
}