using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.Options;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models;
using System.IO;
using TrainDTrainorV2.Core.Models;
using TrainDTrainorV2.Core.Services;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Handlers
{
    public class CourseMaterialCommandHandler : RequestHandlerBase<CourseMaterialCommand, ReadCourseMaterial>
    {        
        private IGridFsService _gridFsService;
        public CourseMaterialCommandHandler(ILoggerFactory loggerFactory,
           IGridFsService gridFsService
            ) : base(loggerFactory)
        {
            _gridFsService = gridFsService;
        }
        protected override Task<ReadCourseMaterial> ProcessAsync(CourseMaterialCommand message, CancellationToken cancellationToken)
        {
            var model = message.CourseMaterial;
            var agent = message.UserAgent;           
            var mediaId = ObjectId.TryParse(model.Id, out ObjectId id);
           
            return Task.Run(()=> {
                if (!mediaId)
                {
                    return new ReadCourseMaterial
                    {
                        ObjectId = _gridFsService.UploadFromStreamAsync(model.File, model.MediaTypeEnum).Result,
                        FileStream = null
                    };
                }
                else
                {
                    var stream = new MemoryStream();
                    _gridFsService.DownloadToStreamByNameAsync(model.FileName, stream, model.MediaTypeEnum);
                    stream.Seek(0, SeekOrigin.Begin);

                    return new ReadCourseMaterial
                    {
                        ObjectId = new ObjectId(model.Id),
                        FileStream = stream
                    };
                }
            });
           
        }      
    }
}
