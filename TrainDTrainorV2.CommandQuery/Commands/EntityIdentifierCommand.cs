using System;
using System.Security.Principal;
using MediatR;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public abstract class EntityIdentifierCommand<TKey, TReadModel> : IRequest<TReadModel>
    {
        protected EntityIdentifierCommand(TKey id)
        {
            Id = id;            
        }
        protected EntityIdentifierCommand(TKey id, IPrincipal principal)
        {
            Id = id;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public TKey Id { get; set; }
    }
}