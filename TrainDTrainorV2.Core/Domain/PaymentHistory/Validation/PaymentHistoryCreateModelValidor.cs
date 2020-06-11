using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Validation
{
    public class PaymentHistoryCreateModelValidor : AbstractValidator<PaymentHistoryCreateModel>
    {
        public PaymentHistoryCreateModelValidor()
        {
            RuleFor(p => p.CourseId).NotNull();
            RuleFor(p => p.UserProfileId).NotNull();            
        }
    }
}
