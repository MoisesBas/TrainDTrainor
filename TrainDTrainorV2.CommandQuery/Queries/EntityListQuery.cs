using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Models;
using MediatR;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class EntityListQuery<TEntity, TReadModel> : IRequest<EntityListResult<TReadModel>>
        where TEntity : class
    {
        public EntityListQuery(EntityQuery<TEntity> query, IPrincipal principal)
        {
            Query = query;
            Principal = principal;
        }
        public EntityListQuery(EntityQuery<TEntity> query)
        {
            Query = query;           
        }

        public IPrincipal Principal { get; set; }

        public EntityQuery<TEntity> Query { get; set; }
    }
}