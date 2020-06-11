using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Achievement.Model;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Validation
{
    public class AchievementUpdateModelValidator : AbstractValidator<AchievementUpdateModel>
    {
        public AchievementUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(150);
            RuleFor(p => p.UserProfileId).NotEmpty();
        }
    }
}
