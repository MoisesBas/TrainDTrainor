using System;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class LevelVideo: IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {
    }
}
