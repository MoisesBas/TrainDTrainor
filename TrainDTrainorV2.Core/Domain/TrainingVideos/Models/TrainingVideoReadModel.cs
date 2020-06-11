using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Models
{
  public  class TrainingVideoReadModel: EntityReadModel<Guid>
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string TrainingName { get; set; }
        public Guid TrainingId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public Guid? FileId { get; set; }
        public bool IsMobile { get; set; }
        public bool IsDesktop { get; set; }
    }
}
