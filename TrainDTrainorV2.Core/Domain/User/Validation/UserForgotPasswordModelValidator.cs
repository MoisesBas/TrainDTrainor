using FluentValidation;
using TrainDTrainorV2.Core.Domain.Models;


namespace TrainDTrainorV2.Core.Domain.Validation
{
    public class UserForgotPasswordModelValidator : AbstractValidator<UserForgotPasswordModel>
    {
        public UserForgotPasswordModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
        }
    }
}