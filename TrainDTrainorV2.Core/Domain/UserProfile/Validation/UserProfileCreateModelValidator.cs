using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Validation
{
    public class UserProfileCreateModelValidator : AbstractValidator<UserProfileCreateModel>
    {
        public UserProfileCreateModelValidator()
        {
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.FullName).MaximumLength(150);
            RuleFor(p => p.Nationality).NotEmpty();
            RuleFor(p => p.Nationality).MaximumLength(150);
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(150);
            RuleFor(p => p.MobilePhone).NotEmpty();
            RuleFor(p => p.MobilePhone).MaximumLength(13);
            RuleFor(p => p.UserId).NotEmpty();

        }
    }
}
