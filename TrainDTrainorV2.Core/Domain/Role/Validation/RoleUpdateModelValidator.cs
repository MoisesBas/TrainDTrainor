using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Role.Validation
{
    public class RoleUpdateModelValidator : AbstractValidator<RoleUpdateModel>
    {
        public RoleUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.Description).MaximumLength(256);

        }
    }
}
