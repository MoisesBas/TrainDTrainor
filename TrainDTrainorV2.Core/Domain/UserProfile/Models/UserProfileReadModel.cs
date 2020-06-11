using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserProfileReadModel: EntityReadModel<Guid>
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
        public Guid? ProfilePicId { get; set; }
        public string MongoDbProfileCVId { get; set; }
        public string ProfilePicPath { get; set; }
        public string FileName { get; set; }
        public Guid? UserId { get; set; }        
    }
}
