using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.API.Utility;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.API.Controllers
{
   
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Videos")]
    [Route("api/videos")]
    public class VideosController : MediatorControllerBase
    {
        private TrainDTrainorContext _dataContext = new TrainDTrainorContext();

        public VideosController(
            IMediator mediator, IGridFsService gridFsService) : base(mediator,gridFsService)
        {
          
        }

        [HttpPost("pic"), DisableRequestSizeLimit]
        public async Task<IActionResult> pic([FromForm] UserProfileUpdateModel updateModel)
        {
            byte[] bytes;
            var path = CreateDir("UserProfilePic");
            //CreateResult result = new CreateResult();
            //if (updateModel.File.Length > 0)
            //{

            //    var fileName = ContentDispositionHeaderValue.Parse(updateModel.File.ContentDisposition).FileName.Trim('"');
            //    using (var reader = new StreamReader(updateModel.File.OpenReadStream()))
            //    {
            //        string contentAsString = reader.ReadToEnd();
            //        bytes = new byte[contentAsString.Length * sizeof(char)];
            //        System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);
            //        var now = DateTimeOffset.Now;
            //        var file = new UserProfilePic()
            //        {
            //            Name = updateModel.File.FileName,
            //            File_stream = bytes,
            //            ParentPath = path,
            //            Creation_time = now,
            //            Last_access_time = now,
            //            Last_write_time = now,

            //        };
            //        result = _dataContext.CreateFile.CallStoredProc(file).ToList<CreateResult>().FirstOrDefault();
            //    }
            //}

            return Ok();


        }

       private string CreateDir(string dirName, string parentPath = null)
        {
            //var dir = new UserProfilePic() { Name = dirName, ParentPath = parentPath };
            //CreateResult result = _dataContext.CreateDir.CallStoredProc(dir).ToList<CreateResult>().FirstOrDefault();
            //return result.Path;   
            return null;
        }

        async Task PushData(Stream stream, CancellationToken cancel)
        {           
            await GridFsService.DownloadToStreamByNameAsync("SampleVideo.mp4", stream, MediaTypeEnum.Videos);
            stream.Seek(0, SeekOrigin.Begin);
        }
        [HttpGet("")]
        public IActionResult Download()
        {
            return new PushStreamResult(PushData, "video/mp4");
        }
        //[HttpGet("")]
        //public async Task<IActionResult> Download(string id)
        //{
        //    var memStream = new MemoryStream();
        //    await _gridFsService.DownloadToStreamByNameAsync("SampleVideo.mp4", memStream, MediaTypeEnum.Videos);
        //    memStream.Seek(0, SeekOrigin.Begin);
        //    return File(memStream, "video/mp4");
        //}
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadVideos([FromForm]IFormFile file)
        {
            var userAgent = Request.UserAgent();
            var uploadCommand = new CourseMaterialCommand(userAgent, new Core.MongoDB.Domain.CourseMaterial.Models.CreateCourseMaterialModel
            {
                File = file,
                MediaTypeEnum = MediaTypeEnum.Videos,
            });
            var result = await Mediator.Send(uploadCommand).ConfigureAwait(false);
            return Ok(result);
        }
    }
}