using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.LevelSubject.Models
{
    public class LevelSubjectCreateModel: EntityCreateModel<Guid>
    {
        public string Name { get; set; }
        public Guid? LevelId { get; set; }       
    }
}
