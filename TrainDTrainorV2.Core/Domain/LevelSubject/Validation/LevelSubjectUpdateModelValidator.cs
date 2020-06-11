using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.LevelSubject.Validation
{
   public class LevelSubjectUpdateModelValidator: AbstractValidator<LevelSubjectUpdateModel>
    {
        public LevelSubjectUpdateModelValidator()
        {
            RuleFor(p => p.LevelId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
