using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Commands;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Services;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Commands;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Videos")]
    [Route("api/trainingvideos")] 
    public class TrainingVideosController : MediatorCommandControllerBase<Guid,
        TrainingVideo,
        TrainingVideoReadModel,        
        TrainingVideoCreateModel,
        TrainingVideoUpdateModel>
    {
        public TrainingVideosController(IMediator mediator,
            IGridFsService gridFsService) : base(mediator, gridFsService)
        {

        }
        [HttpPost("Update")]
        [ProducesResponseType(typeof(TrainingVideoReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken,
           Guid id,
           [FromForm] TrainingVideoUpdateModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new TrainingVideoUpdateCommand<TrainingVideoUpdateModel,Guid>(id,model,null,userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }

        [HttpPost("insert"), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(TrainingVideoReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,          
           [FromForm] TrainingVideoCreateModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new TrainingVideoCommand<TrainingVideoCreateModel>(model, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(TrainingVideoReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
          Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [AllowAnonymous]
        [HttpGet("GetTrainingVideosByFileId")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetTrainingVideosById(CancellationToken cancellationToken, Guid fileId)
        {
            var memory = new MemoryStream();           
            var command = new TrainingVideoGetCommand<Guid>(fileId);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            using (var stream = new FileStream(result.Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(result.Path), Path.GetFileName(result.Path));           
        }       
    }
}