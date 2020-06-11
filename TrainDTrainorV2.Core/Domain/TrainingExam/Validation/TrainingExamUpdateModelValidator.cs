using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExam.Validation
{
    public class TrainingExamUpdateModelValidator: AbstractValidator<TrainingExamUpdateModel>
    {
        public TrainingExamUpdateModelValidator()
        {
            RuleFor(p => p.Question).NotEmpty();
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.Answer).NotEmpty();
            RuleFor(p => p.QuestionType).NotNull();
        }
    }
}
