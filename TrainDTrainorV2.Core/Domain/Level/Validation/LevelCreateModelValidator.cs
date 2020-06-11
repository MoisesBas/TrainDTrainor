using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.Level.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Validation
{
   public class LevelCreateModelValidator : AbstractValidator<LevelCreateModel>
    {
        public LevelCreateModelValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Title).MaximumLength(256);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.TrainingId).NotNull();
        }
    }
}
