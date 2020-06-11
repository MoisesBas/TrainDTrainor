using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Models
{
   public class LevelBestVideoReadModel: EntityReadModel<Guid>
    {
      public string Name { get; set; }
      public string Description { get; set; }
      public string LevelName { get; set; }
      public Guid? LevelId { get; set; }
      public string Path { get; set; }
      public string FileName { get; set; }
      public Guid? BestVideoId { get; set; }
    }
}
