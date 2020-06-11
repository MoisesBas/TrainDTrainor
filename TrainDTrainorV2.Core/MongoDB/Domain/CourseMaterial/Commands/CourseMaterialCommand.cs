using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Models;
using MongoDB.Driver.GridFS;
using System.IO;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Commands
{
    public class CourseMaterialCommand:IRequest<ReadCourseMaterial>
    {
        public CourseMaterialCommand(UserAgentModel userAgent,CreateCourseMaterialModel courseMaterial)
        {
            CourseMaterial = courseMaterial;
            UserAgent = userAgent;
        }        
        public CreateCourseMaterialModel CourseMaterial { get; set; }
        public UserAgentModel UserAgent { get; set; }
    }
}
