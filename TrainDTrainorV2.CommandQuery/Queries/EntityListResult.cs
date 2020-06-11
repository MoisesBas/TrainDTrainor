using System;
using System.Collections.Generic;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class EntityListResult<TReadModel>
    {
        public long Total { get; set; }

        public IReadOnlyCollection<TReadModel> Data { get; set; }
    }
}