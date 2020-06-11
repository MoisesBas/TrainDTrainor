using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface IUpdateParams: IStreamId
    {
        Byte[] File_stream { get; set; }
    }
}
