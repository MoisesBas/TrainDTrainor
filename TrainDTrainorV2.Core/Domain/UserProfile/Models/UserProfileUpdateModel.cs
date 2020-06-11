using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Utility;

namespace TrainDTrainorV2.Core.Domain.Models
{
    
    public   class UserProfileUpdateModel: EntityUpdateModel
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
        public string DbProfilePicId { get; set; }
        public string DbProfileCVId { get; set; }
        public Guid? UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
