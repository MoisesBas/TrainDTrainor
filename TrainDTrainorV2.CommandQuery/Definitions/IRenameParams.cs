using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
   public interface IRenameParams: IStreamId    
    {
        string Name { get; set; }
    }
}
