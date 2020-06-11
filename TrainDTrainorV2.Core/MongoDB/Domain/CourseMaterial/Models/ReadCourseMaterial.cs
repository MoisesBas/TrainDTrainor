using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models
{
    public class ReadCourseMaterial
    {
        public ObjectId ObjectId { get; set; }
        public Stream FileStream { get; set; }
    }
}
