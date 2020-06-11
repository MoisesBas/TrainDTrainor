﻿using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
   public partial class PaymentTransactionHistory: IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated,ITrackDeleted
    {
    }
}
