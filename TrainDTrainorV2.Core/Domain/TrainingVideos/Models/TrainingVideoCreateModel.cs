using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Models
{
    public class TrainingVideoCreateModel : EntityCreateModel<Guid>
    {
        public TrainingVideoCreateModel()
        {
            IsMobile = false;
            IsDesktop = false;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrainingMongDbId { get; set; }
        public bool IsMobile { get; set; }
        public bool IsDesktop { get; set; }
        public Guid TrainingId { get; set; }
        public IFormFile File { get; set; }
    }
}
