using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Validation
{
  public  class PaymentUpdateModelValidator : AbstractValidator<PaymentUpdateModel>
    {
        public PaymentUpdateModelValidator()
        {
            RuleFor(p => p.CourseId).NotEmpty();
            RuleFor(p => p.UserProfileId).NotEmpty();            
        }
    }
}
