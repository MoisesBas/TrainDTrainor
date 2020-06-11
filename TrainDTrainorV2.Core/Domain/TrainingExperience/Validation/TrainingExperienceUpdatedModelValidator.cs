using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Validation
{
  public  class TrainingExperienceUpdatedModelValidator: AbstractValidator<TrainingExperienceUpdatedModel>
    {
        public TrainingExperienceUpdatedModelValidator()
        {
            RuleFor(p => p.UserProfileId).NotNull();
            RuleFor(p => p.CourseName).NotEmpty();
        }
    }
}
