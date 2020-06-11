using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Models
{
  public  class TrainingExperienceCreatedModel: EntityCreateModel<Guid>
    {
        public Guid? UserProfileId { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public int Attended { get; set; }
        public int Year { get; set; }
    }
}
