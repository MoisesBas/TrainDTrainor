using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Queries
{
   public class EntitySingleResult<TReadModel>
    {
        public TReadModel Data { get; set; }
    }
}
