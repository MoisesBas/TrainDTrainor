using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Validation
{
    public class CourseMaterialUpdateModelValidator: AbstractValidator<CourseMaterialCreateModel>
    {
        public CourseMaterialUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(150);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(256);
            RuleFor(p => p.Type).NotNull();
            RuleFor(p => p.CourseId).NotNull();
        }
    }
}
