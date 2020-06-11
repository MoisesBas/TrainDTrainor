using System;
using FluentValidation;
using TrainDTrainorV2.Core.Domain.Models;


namespace TrainDTrainorV2.Core.Domain.Validation
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);

            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);

            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(8);
        }
    }
}