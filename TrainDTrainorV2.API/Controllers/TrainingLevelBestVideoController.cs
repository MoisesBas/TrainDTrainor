using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands;
using TrainDTrainorV2.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Level")]
    [Route("api/levelvideo")]
    public class TrainingLevelBestVideoController : MediatorCommandControllerBase<Guid,
        LevelVideo,
        LevelBestVideoReadModel,
        LevelBestVideoCreateModel,
        LevelBestVideoUpdateModel>
    {
        public TrainingLevelBestVideoController(IMediator mediator, IAppCache cache) : base(mediator,cache)
        {
        }
        [HttpPost("Insert"), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(LevelBestVideoReadModel), 200)]
        public async Task<IActionResult> Insert(
            [FromForm] LevelBestVideoCreateModel model, CancellationToken cancellationToken)
        {
            var userAgent = Request.UserAgent();
            var command = new LevelBestVideoCommand<LevelBestVideoCreateModel>(model, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [AllowAnonymous]
        [HttpGet("GetLevelBestVideosByFileId")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetTrainingVideosById(CancellationToken cancellationToken, Guid fileId)
        {
            var memory = new MemoryStream();
            var command = new LevelBestVideoGetCommand<Guid>(fileId);
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