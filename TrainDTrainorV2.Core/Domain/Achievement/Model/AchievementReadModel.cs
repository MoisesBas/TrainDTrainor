using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Achievement.Model
{
public  class AchievementReadModel: EntityReadModel<Guid>
    {
        public string Name { get; set; }
        public Guid? UserProfileId { get; set; }
    }
}
