using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Validation
{
   public class TrainingExperienceCreatedModelValidator: AbstractValidator<TrainingExperienceCreatedModel>
    {
        public TrainingExperienceCreatedModelValidator()
        {
            RuleFor(p => p.UserProfileId).NotNull();
            RuleFor(p => p.CourseName).NotEmpty();           
        }
    }
}
