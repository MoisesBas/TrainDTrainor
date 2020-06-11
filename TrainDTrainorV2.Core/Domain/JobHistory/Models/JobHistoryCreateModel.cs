using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.JobHistory.Models
{
    public class JobHistoryCreateModel: EntityCreateModel<Guid>
    {
        public Guid? UserProfileId { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public int Years { get; set; }
    }
}
