using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.CommitteeQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.CommitteeQuestion.Validation
{
    
    public class CommitteeQuestionUpdateModelValidator : AbstractValidator<CommitteeQuestionUpdateModel>
    {
        public CommitteeQuestionUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.Description).NotEmpty();           
            RuleFor(p => p.QuestionType).NotEmpty();
        }
    }
}
