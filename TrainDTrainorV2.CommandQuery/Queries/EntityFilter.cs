using System;
using System.Collections.Generic;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class EntityFilter
    {
        public string Name { get; set; }

        public string Operator { get; set; }

        public object Value { get; set; }

        public string Logic { get; set; }

        public IEnumerable<EntityFilter> Filters { get; set; }
    }
}