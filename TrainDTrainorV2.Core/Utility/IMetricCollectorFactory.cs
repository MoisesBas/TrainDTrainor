using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Utility
{
    interface IMetricCollectorFactory
    {
        IMetricCollector Create<T>();
        IMetricCollector Create(Type type);
    }
}
