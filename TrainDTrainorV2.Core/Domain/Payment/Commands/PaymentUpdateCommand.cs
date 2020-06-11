using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Commands
{

    public class PaymentUpdateCommand<TUpdateModel, TKey> : EntityUpdateCommand<TKey, PaymentTransaction, TUpdateModel, PaymentReadModel>
    {        
        public PaymentUpdateCommand(TKey id, TUpdateModel model, IPrincipal principal,
            UserAgentModel userAgent) : base(id, model, principal)
        {
            Payment = model;
            Id = id;
            UserAgent = userAgent;
        }
        public TUpdateModel Payment { get; set; }   
        public UserAgentModel UserAgent { get; set; }
    }
}
