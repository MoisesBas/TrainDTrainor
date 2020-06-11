using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Training.Models;

namespace TrainDTrainorV2.Core.Domain.Training.Validation
{
    public class TrainingUpdateModelValidator : AbstractValidator<TrainingUpdateModel>
    {
        public TrainingUpdateModelValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Title).MaximumLength(256);
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
