using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Queries
{
   public class EntityDeleteQuery<TEntity, TReadModel>: IRequest<bool>
        where TEntity : class
    {
        public EntityDeleteQuery(SingleQuery<TEntity> query, IPrincipal principal)
        {
            Query = query;
            Principal = principal;
        }
        public IPrincipal Principal { get; set; }

        public SingleQuery<TEntity> Query { get; set; }
    }
}
