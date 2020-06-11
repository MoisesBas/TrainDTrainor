using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.LevelQuestion.Validation
{
    public class LevelQuestionCreateModelValidator : AbstractValidator<LevelQuestionCreateModel>
    {
        public LevelQuestionCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.LevelId).NotEmpty();
            RuleFor(p => p.QuestionType).NotEmpty();
        }
    }
}
