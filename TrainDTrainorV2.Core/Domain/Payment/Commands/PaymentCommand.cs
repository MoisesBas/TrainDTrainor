using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Commands
{   
    public class PaymentCommand : IRequest<PaymentReadModel>
    {
        public PaymentCommand(PaymentCreateModel payment)
        {
            Payment = payment;
        }
        public PaymentCreateModel Payment { get; set; }
    }
}
