using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Commands;

namespace TrainDTrainorV2.Core.Domain.Payment.Commands
{
    public class PaymentApprovalCommand<TKey,TEntity,TReadModel>: EntityIdentifierCommand<TKey, TReadModel>
        where TEntity:class, new()
    {
        public PaymentApprovalCommand(TKey id, IPrincipal principal,
             int paymentStatus) :base(id,principal)
        {
            PaymentStatus = paymentStatus;
        }       
        public int PaymentStatus { get; set; }
    }
}
