﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private static readonly Lazy<string> _requestName = new Lazy<string>(() => typeof(TRequest).Name);

        protected RequestHandlerBase(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(GetType());
        }

        protected ILogger Logger { get; }

        public virtual async Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogTrace("Processing request '{0}' ...", _requestName.Value);
                var watch = Stopwatch.StartNew();

                var response = await ProcessAsync(message, cancellationToken).ConfigureAwait(false);

                watch.Stop();
                Logger.LogTrace("Processed request '{0}': {1} ms", _requestName.Value, watch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error handling request '{0}': {1}", _requestName.Value, ex.Message);
                throw;
            }
        }

        protected abstract Task<TResponse> ProcessAsync(TRequest message, CancellationToken cancellationToken);
    }
}