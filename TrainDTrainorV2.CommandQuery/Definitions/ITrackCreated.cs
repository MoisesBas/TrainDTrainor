using System;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface ITrackCreated
    {
        DateTimeOffset Created { get; set; }
        string CreatedBy { get; set; }
    }
}