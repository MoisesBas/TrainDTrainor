﻿using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public class EntityDeleteCommand<TKey, TEntity, TReadModel> : EntityIdentifierCommand<TKey, TReadModel>
        where TEntity : class, new()
    {
        public EntityDeleteCommand(TKey id, IPrincipal principal) : base(id, principal)
        {
        }
    }
}