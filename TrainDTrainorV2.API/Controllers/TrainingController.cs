using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Training.Models;
using TrainDTrainorV2.Core.Domain.Training.Commands;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.CommandQuery.Queries;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE TOT")]
    [Route("api/training")]      
    public class TrainingController : MediatorCommandControllerBase<Guid,
        Training,
        TrainingReadModel,     
        TrainingCreateModel,
        TrainingUpdateModel>
    {
        public TrainingController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {

        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(TrainingReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           TrainingUpdateModel model)
        {           
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Trainings.ToString());
            Cache.Remove(CacheKey.Trainings.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(TrainingReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           TrainingCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Trainings.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(TrainingReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Trainings.ToString());
            Cache.Remove(CacheKey.Trainings.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrainingDetailReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var command = new TrainingDetailCommand(id);
            Task<TrainingDetailReadModel> readModel() => Mediator.Send(command, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Trainings.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });

        }
        [HttpGet("")]
        [ProducesResponseType(typeof(TrainingReadModel), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new EntityQuery<Training>();     

            Task<EntityListResult<TrainingReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Trainings.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
    }
}