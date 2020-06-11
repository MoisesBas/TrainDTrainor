﻿using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Role.Models
{
  public  class CountryCreateModel : EntityCreateModel<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
