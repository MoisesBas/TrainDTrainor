using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Education.Models
{
    public class EducationCreateModel: EntityCreateModel<Guid>
    {
        public Guid? UserProfileId { get; set; }
        public string DegreeName { get; set; }
        public string NameOfInstitute { get; set; }
        public string EducationLevel { get; set; }
        public int Year { get; set; }
    }
}
