using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Models
{
  public class LevelBestVideoUpdateModel: EntityUpdateModel
    {
        public Guid? LevelId { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
        public Guid? LevelVideoId { get; set; }
        public IFormFile File { get; set; }
    }
}
