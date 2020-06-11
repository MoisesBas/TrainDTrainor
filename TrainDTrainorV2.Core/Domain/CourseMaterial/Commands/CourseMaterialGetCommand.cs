using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Commands
{
    
    public class CourseMaterialGetCommand<TKey> : EntityIdentifierCommand<TKey, CourseMaterialReadModel>
    {
        public CourseMaterialGetCommand(TKey id) : base(id)
        {
        }
    }
}
