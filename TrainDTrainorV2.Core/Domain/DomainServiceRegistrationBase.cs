﻿using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Behaviors;
using KickStart.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TrainDTrainorV2.Core.Domain
{
    public abstract class DomainServiceRegistrationBase : IDependencyInjectionRegistration
    {
        public abstract void Register(IServiceCollection services, IDictionary<string, object> data);

        protected virtual void RegisterEntityCommand<TKey, TEntity, TReadModel, TCreateModel, TUpdateModel>(IServiceCollection services)
            where TEntity : class, new()
            where TCreateModel : class
            where TUpdateModel : class
        {
            // standard crud commands
            services.TryAddTransient<IRequestHandler<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, EntityCreateCommandHandler<TEntity, TCreateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>, TReadModel>, EntityUpdateCommandHandler<TKey, TEntity, TUpdateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityPatchCommand<TKey, TEntity, TReadModel>, TReadModel>, EntityPatchCommandHandler<TKey, TEntity, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityDeleteCommand<TKey, TEntity, TReadModel>, TReadModel>, EntityDeleteCommandHandler<TKey, TEntity, TReadModel>>();

            // bulk crud commands 
            services.TryAddTransient<IRequestHandler<EntityBulkCreateCommand<TEntity, TCreateModel, TReadModel>, IEnumerable<TReadModel>>, EntityBulkCreateCommandHandler<TEntity, TCreateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityBulkDeleteCommand<TEntity, TUpdateModel, TReadModel>, IEnumerable<TReadModel>>, EntityBulkDeleteCommandHandler<TEntity, TUpdateModel, TReadModel>>();

            // pipeline registration,  run in order registered
            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, AuthenticateEntityModelCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>, TReadModel>, AuthenticateEntityModelCommandBehavior<TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TEntity, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityDeleteCommand<TKey, TEntity, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TUpdateModel, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>, TReadModel>, TrackChangeEntityUpdateCommandBehavior<TKey, TEntity, TUpdateModel, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TEntity, TReadModel>, TReadModel>, TrackChangeEntityPatchCommandBehavior<TKey, TEntity, TReadModel>>();
            //testing for delete
           
            services.TryAddTransient<IRequestHandler<EntityDeleteQuery<TEntity, TReadModel>, bool>, EntitySingleDeleteCommandHandler<TEntity, TReadModel>>();
        }

        protected virtual void RegisterEntityQuery<TKey, TEntity, TReadModel>(IServiceCollection services)
           where TEntity : class, new()
        {
            // standard queries
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<TKey, TEntity, TReadModel>, TReadModel>, EntityIdentifierQueryHandler<TKey, TEntity, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityListQuery<TEntity, TReadModel>, EntityListResult<TReadModel>>, EntityListQueryHandler<TEntity, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntitySingleQuery<TEntity, TReadModel>, EntitySingleResult<TReadModel>>, EntitySingleQueryHandler<TEntity, TReadModel>>();
        }


    }
}
