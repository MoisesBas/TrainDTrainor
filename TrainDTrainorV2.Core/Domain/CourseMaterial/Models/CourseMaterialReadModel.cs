using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Models
{
    public class CourseMaterialReadModel: EntityReadModel<Guid>
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public int Type { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid FileId { get; set; }
        public bool? IsDeleted { get; set; }
        public IFormFile File { get; set; }
    }
}
