using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainDTrainorV2.Core.Enum;

namespace TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models
{
   public class CreateCourseMaterialModel
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public MediaTypeEnum MediaTypeEnum { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
        public string UpdatedBy { get; set; }
    }
}
