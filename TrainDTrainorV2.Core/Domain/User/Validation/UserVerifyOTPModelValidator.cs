using FluentValidation;

using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.User.Validation
{
    public class UserVerifyOTPModelValidator : AbstractValidator<UserVerifyOTPModel>
    {
        public UserVerifyOTPModelValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.OTP).NotNull();
        }
    }
}
