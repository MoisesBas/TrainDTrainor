﻿using System;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.CommandQuery.Models
{
    public abstract class EntityReadModel<TKey> : IHaveIdentifier<TKey>, ITrackCreated, ITrackUpdated, ITrackConcurrency
    {
        public TKey Id { get; set; }

        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

        public string CreatedBy { get; set; }

        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;

        public string UpdatedBy { get; set; }

        public string RowVersion { get; set; }
    }
}