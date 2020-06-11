using System;
using TrainDTrainorV2.CommandQuery.Definitions;
using TrainDTrainorV2.Core.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class UserProfile : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated,ITrackDeleted
    {

    }
}
