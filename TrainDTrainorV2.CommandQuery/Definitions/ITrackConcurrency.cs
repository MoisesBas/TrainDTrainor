using System;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface ITrackConcurrency
    {
        string RowVersion { get; set; }
    }
}