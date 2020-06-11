using System;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface ITrackUpdated
    {
        DateTimeOffset Updated { get; set; }
        string UpdatedBy { get; set; }
    }
}