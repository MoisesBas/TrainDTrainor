﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public class EntityIdentifierQueryHandler<TKey, TEntity, TReadModel> : RequestHandlerBase<EntityIdentifierQuery<TKey, TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public EntityIdentifierQueryHandler(ILoggerFactory loggerFactory, DbContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<TReadModel> ProcessAsync(EntityIdentifierQuery<TKey, TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var dbSet = _context
                .Set<TEntity>();

            var keyValue = new object[] { message.Id };

            // find entity by message id
            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken)
                .ConfigureAwait(false);

            if (entity == null)
                return default(TReadModel);

            // return read model
            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }
    }
}
