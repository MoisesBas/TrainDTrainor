using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Validation
{
    public class PaymentCreateModelValidor : AbstractValidator<PaymentCreateModel>
    {
        public PaymentCreateModelValidor()
        {
            RuleFor(p => p.CourseId).NotNull();
            RuleFor(p => p.UserProfileId).NotNull();            
        }
    }
}
