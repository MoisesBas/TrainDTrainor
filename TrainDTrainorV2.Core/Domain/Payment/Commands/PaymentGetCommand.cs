using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Commands
{
    public class PaymentGetCommand: IRequest<PaymentReadModel>
    {
        public PaymentGetCommand(Guid? profileId)
        {
            ProfileId = profileId;
        }
        public Guid? ProfileId { get; set; }
    }  
}
