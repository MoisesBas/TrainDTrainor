using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.UserRole.Models;

namespace TrainDTrainorV2.Core.Domain.UserRole.Validation
{
    public class UserRoleCreateModelValidator : AbstractValidator<UserRoleCreateModel>
    {
        public UserRoleCreateModelValidator()
        {
            RuleFor(p => p.RoleId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserType).NotEmpty();
        }
    }
}
