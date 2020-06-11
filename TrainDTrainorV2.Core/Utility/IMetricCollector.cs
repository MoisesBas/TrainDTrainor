using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Utility
{
    internal interface IMetricCollector
    {
        void Complete();
        void CompleteWithError();
    }
}
