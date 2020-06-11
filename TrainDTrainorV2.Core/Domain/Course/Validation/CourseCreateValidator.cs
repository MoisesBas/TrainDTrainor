using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Validation
{
    public class CourseCreateValidator: AbstractValidator<CourseCreateModel>
    {
        public CourseCreateValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.TrainorId).NotNull();
            RuleFor(p => p.TrainingId).NotNull();
            RuleFor(p => p.MaxAttendee).NotNull();
        }
    }
}
