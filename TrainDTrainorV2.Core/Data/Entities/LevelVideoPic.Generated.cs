﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class LevelVideoPic
    {
        [Key]
        public Guid Stream_id { get; set; }

        public Byte[] File_stream { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string ParentPath { get; set; }

        //public string File_type { get; }

        //public Int64 Cached_file_size { get; }

        public DateTimeOffset Creation_time { get; set; }

        public DateTimeOffset Last_write_time { get; set; }

        public DateTimeOffset Last_access_time { get; set; }

        public bool Is_directory { get; set; }

        public bool Is_offline { get; set; }

        public bool Is_hidden { get; set; }

        public bool Is_readonly { get; set; }

        public bool Is_archive { get; set; }

        public bool Is_system { get; set; }

        public bool Is_temporary { get; set; }
        public string fullpath { get; set; }
        public Guid Id { get; set; }       
    }
}
