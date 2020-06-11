using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Models;
using MediatR;
using TrainDTrainorV2.CommandQuery.Helper;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class EntitySingleQuery<TEntity, TReadModel> : IRequest<EntitySingleResult<TReadModel>>
        where TEntity : class
    {
        public EntitySingleQuery(SingleQuery<TEntity> query)
        {
            Query = query;           
        }
        public EntitySingleQuery(SingleQuery<TEntity> query, IPrincipal principal)
        {
            Query = query;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public SingleQuery<TEntity> Query { get; set; }

    }
}