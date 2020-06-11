using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Enum;

namespace TrainDTrainorV2.Core.Services
{
  public  interface IGridFsService
    {
        Task<ObjectId> UploadFromStreamAsync(IFormFile file, MediaTypeEnum bucketName);

        Task DownloadToStreamByNameAsync(string gfsname, Stream source, MediaTypeEnum bucketName);

        Task DownloadToStreamAsync(ObjectId id, Stream source, MediaTypeEnum bucketName);

        //Task<GridFSDownloadStream> OpenDownloadStreamAsync(ObjectId id, MediaTypeEnum bucketName);

        //Task<GridFSDownloadStream> OpenDownloadStreamByNameAsync(string name, MediaTypeEnum bucketName);
        //Task<bool> FileExistsAsync(string gfsname, MediaTypeEnum bucketName);
    }
}
