using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Validation
{
    public class CourseUpdateValidator: AbstractValidator<CourseUpdateModel>
    {
        public CourseUpdateValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.TrainorId).NotNull();
            RuleFor(p => p.TrainingId).NotNull();
            RuleFor(p => p.MaxAttendee).NotNull();
        }
    }
}
