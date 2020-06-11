using System;
using System.Security.Principal;
using MediatR;
using TrainDTrainorV2.CommandQuery.Helper;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public abstract class EntityModelCommand<TEntityModel, TReadModel> : IRequest<TReadModel>
    {
        protected EntityModelCommand(TEntityModel model, IPrincipal principal)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Model = model;
            Principal = principal;          
        }
        protected EntityModelCommand(TEntityModel model, IQuery<TEntityModel> filter, IPrincipal principal)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Model = model;
            Principal = principal;
            Filter = filter;
        }
        public IPrincipal Principal { get; set; }

        public TEntityModel Model { get; set; }
        public IQuery<TEntityModel> Filter { get; set; }
    }
}