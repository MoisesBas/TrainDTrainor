using System;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface IHaveIdentifier<TKey>
    {
        TKey Id { get; set; }
    }
}