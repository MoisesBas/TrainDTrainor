using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Validation
{
   public class ExamResultUpdateModelValidator: AbstractValidator<ExamResultUpdateModel>
    {
        public ExamResultUpdateModelValidator()
        {
            RuleFor(p => p.UserId).NotNull();
            RuleFor(p => p.QuestionId).NotNull();
            RuleFor(p => p.CourseId).NotNull();
            RuleFor(p => p.Answer).NotEmpty();
            RuleFor(p => p.IsCorrect).NotNull();
        }
    }
}
