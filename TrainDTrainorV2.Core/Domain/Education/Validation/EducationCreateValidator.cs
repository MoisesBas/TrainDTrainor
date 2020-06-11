using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.Core.Domain.Education.Validation
{
    public class EducationCreateValidator: AbstractValidator<EducationCreateModel>
    {
        public EducationCreateValidator()
        {
            RuleFor(p => p.UserProfileId).NotEmpty();
            RuleFor(p => p.DegreeName).NotEmpty();
            RuleFor(p => p.DegreeName).MaximumLength(150);
            RuleFor(p => p.NameOfInstitute).NotEmpty();
            RuleFor(p => p.NameOfInstitute).MaximumLength(150);
        }
    }
}
