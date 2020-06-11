using System;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserSendOTPModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }       
    }
}
