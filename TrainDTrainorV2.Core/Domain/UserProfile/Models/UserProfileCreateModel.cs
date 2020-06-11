using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
  public class UserProfileCreateModel: EntityCreateModel<Guid>
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string MongoDbProfilePicId { get; set; }
        public string MongoDbProfileCVId { get; set; }
        public Guid? UserId { get; set; }
    }
}
