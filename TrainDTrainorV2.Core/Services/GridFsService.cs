using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.MongoDB;
using TrainDTrainorV2.Core.Options;
using MimeKit;
using Microsoft.AspNetCore.Http;

namespace TrainDTrainorV2.Core.Services
{
    public class GridFsService:IGridFsService
    {
        private readonly IOptions<MongoConnectionConfiguration> _mongoConfiguration;
        private IMongoDatabase _mongoDatabase;
        public GridFsService(IOptions<MongoConnectionConfiguration> mongoConfiguration)
        {
            _mongoConfiguration = mongoConfiguration;
            _mongoDatabase = MongoFactory.GetDatabaseFromConnectionString(_mongoConfiguration.Value.ConnectionString + "/" + _mongoConfiguration.Value.Database);
        }
        public async Task<ObjectId> UploadFromStreamAsync(IFormFile file, MediaTypeEnum bucketName)
        {
            var bucket = new GridFSBucket(_mongoDatabase, new GridFSBucketOptions
            {
                BucketName = bucketName.ToString()
            });

            var options = new GridFSUploadOptions
            {              
                Metadata = new BsonDocument {
                    { "filename", file.FileName },
                    { "contentType", file.ContentType }
                }
            };

            return await bucket.UploadFromStreamAsync(file.FileName, file.OpenReadStream(), options);
        }

        public async Task DownloadToStreamByNameAsync(string gfsname, Stream source, MediaTypeEnum bucketName)
        {
            var bucket = new GridFSBucket(_mongoDatabase, new GridFSBucketOptions
            {
                BucketName = bucketName.ToString()
            });
            
          await bucket.DownloadToStreamByNameAsync(gfsname, source);
           
        }

        public async Task DownloadToStreamAsync(ObjectId id, Stream source, MediaTypeEnum bucketName)
        {
            var bucket = new GridFSBucket(_mongoDatabase, new GridFSBucketOptions
            {
                BucketName = bucketName.ToString()
            });

            await bucket.DownloadToStreamAsync(id,source);
            
        }
       
    }
}
