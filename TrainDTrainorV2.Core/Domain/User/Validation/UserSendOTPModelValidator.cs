using FluentValidation;

using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.User.Validation
{
    public class UserSendOTPModelValidator: AbstractValidator<UserSendOTPModel>
    {
        public UserSendOTPModelValidator()
        {
            RuleFor(p => p.PhoneNumber).NotEmpty();            
        }
    }
}
