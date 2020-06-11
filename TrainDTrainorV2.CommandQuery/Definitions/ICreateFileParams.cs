using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Definitions
{
    public interface ICreateFileParams:ICreateDirParams
    {
        Byte[] File_stream { get; set; }
        bool Is_hidden { get; set; }
        bool Is_readonly { get; set; }
        bool Is_archive { get; set; }
        bool Is_system { get; set; }
        bool Is_temporary { get; set; }
    }
}
