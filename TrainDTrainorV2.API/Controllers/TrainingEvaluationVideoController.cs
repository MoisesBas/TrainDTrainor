using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    [SwaggerTag("CREATE, READ, UPDATE & DELETE")]
    [Route("api/evaluationvideo")]
    public class TrainingEvaluationVideoController : MediatorCommandControllerBase<Guid,
        TraineeEvaluationVideo,
        EvaluationVideoReadModel,
        EvaluationVideoCreateModel,
        EvaluationVideoUpdateModel>
    {
        public TrainingEvaluationVideoController(IMediator mediator, IAppCache cache) : base(mediator, cache)
        {
        }
        [HttpPost("Insert"), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(EvaluationVideoReadModel), 200)]
        public async Task<IActionResult> Insert(
            [FromForm] EvaluationVideoCreateModel model, CancellationToken cancellationToken)
        {
            var userAgent = Request.UserAgent();
            var command = new EvaluationVideoCommand<EvaluationVideoCreateModel>(model, userAgent);
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
        [HttpGet("GetEvaluationVideosByFileId")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetTrainingVideosById(CancellationToken cancellationToken, Guid fileId)
        {
            var memory = new MemoryStream();
            var command = new EvaluationVideoGetCommand<Guid>(fileId);
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