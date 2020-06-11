using System;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class User : IHaveIdentifier<Guid>, ITrackDeleted,ITrackUpdated,ITrackCreated
    {

    }
}
