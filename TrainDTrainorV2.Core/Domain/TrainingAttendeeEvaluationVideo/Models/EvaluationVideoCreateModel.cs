using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models
{
  public  class EvaluationVideoCreateModel: EntityCreateModel<Guid>
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TrainingBuildCourseAttendeeId { get; set; }
        public Guid CourseLevelId { get; set; }
        public IFormFile File { get; set; }
    }
}
