using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Validation
{
  public  class PaymentHistoryUpdateModelValidator : AbstractValidator<PaymentHistoryUpdateModel>
    {
        public PaymentHistoryUpdateModelValidator()
        {
            RuleFor(p => p.CourseId).NotEmpty();
            RuleFor(p => p.UserProfileId).NotEmpty();            
        }
    }
}
