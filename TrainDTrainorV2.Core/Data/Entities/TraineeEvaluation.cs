using System;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TraineeEvaluation: IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated,ITrackDeleted
    {
    }
}
