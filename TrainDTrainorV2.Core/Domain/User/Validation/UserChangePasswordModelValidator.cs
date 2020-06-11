using FluentValidation;
using TrainDTrainorV2.Core.Domain.Models;


namespace TrainDTrainorV2.Core.Domain.Validation
{
    public class UserChangePasswordModelValidator : AbstractValidator<UserChangePasswordModel>
    {
        public UserChangePasswordModelValidator()
        {
            RuleFor(p => p.CurrentPassword).NotEmpty();

            RuleFor(p => p.UpdatedPassword).NotEmpty();
            RuleFor(p => p.UpdatedPassword).MinimumLength(8);
        }
    }
}