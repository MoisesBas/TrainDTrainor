using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Validation
{
   public class ExamResultCreateModelValidator: AbstractValidator<ExamResultCreateModel>
    {
        public ExamResultCreateModelValidator()
        {
            RuleFor(p => p.UserId).NotNull();          
            RuleFor(p => p.CourseId).NotNull();           
        }
    }
}
