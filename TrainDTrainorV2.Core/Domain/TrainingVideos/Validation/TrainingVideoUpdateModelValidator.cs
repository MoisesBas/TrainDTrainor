using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Validation
{
    public class TrainingVideoUpdateModelValidator : AbstractValidator<TrainingVideoUpdateModel>
    {
        public TrainingVideoUpdateModelValidator()
        {           
            RuleFor(p => p.TrainingId).NotEmpty();
            RuleFor(p => p.TrainingMongDbId).NotEmpty();
           
        }
    }
}
