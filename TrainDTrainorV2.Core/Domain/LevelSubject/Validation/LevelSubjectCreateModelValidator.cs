using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;

namespace TrainDTrainorV2.Core.Domain.LevelSubject.Validation
{
    public class LevelSubjectCreateModelValidator: AbstractValidator<LevelSubjectCreateModel>
    {
        public LevelSubjectCreateModelValidator()
        {
            RuleFor(p => p.LevelId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
