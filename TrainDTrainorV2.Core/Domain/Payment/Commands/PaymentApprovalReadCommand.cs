using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Commands
{
   public class PaymentApprovalReadCommand<TPaymentDetailApproval> : IRequest<EntityListResult<PaymentDetailApprovalModel>>
    {
        public PaymentApprovalReadCommand(EntityQuery<TPaymentDetailApproval> entityQuery, int paymentStatus)
        {
            EntityQuery = entityQuery;
            PaymentStatus = paymentStatus;
        }
        public int PaymentStatus { get; set; }
        public EntityQuery<TPaymentDetailApproval> EntityQuery { get; set; }
    }
}
