using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Country.Models
{
   public class CountryUpdateModel : EntityUpdateModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
