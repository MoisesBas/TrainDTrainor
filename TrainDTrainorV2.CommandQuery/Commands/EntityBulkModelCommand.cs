using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public abstract class EntityBulkModelCommand<TEntityModel, TReadModel> : IRequest<TReadModel>
    {
        protected EntityBulkModelCommand(IEnumerable<TEntityModel> model, IPrincipal principal)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public IEnumerable<TEntityModel> Model { get; set; }

    }
}
