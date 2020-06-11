using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Validation
{
   public class LevelBestVideoCreateModelValidator: AbstractValidator<LevelBestVideoCreateModel>
    {
        public LevelBestVideoCreateModelValidator()
        {
            RuleFor(p => p.VideoName).NotEmpty();
            RuleFor(p => p.LevelId).NotNull();      
            RuleFor(p => p.File).NotNull();
        }
    }
}
