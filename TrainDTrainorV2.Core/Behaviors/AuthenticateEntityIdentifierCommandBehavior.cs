﻿using System;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.Core.Behaviors
{
    public class AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel> : PipelineBehaviorBase<EntityIdentifierCommand<TKey, TReadModel>, TReadModel>
    {
        public AuthenticateEntityIdentifierCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityIdentifierCommand<TKey, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}
