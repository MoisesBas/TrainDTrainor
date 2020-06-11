using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Level.Commands;
using TrainDTrainorV2.Core.Domain.Level.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Level")]
    [Route("api/level")]
    public class TrainingLevelController : MediatorCommandControllerBase<Guid,
        Level,
        LevelReadModel,
        LevelCreateModel,
        LevelUpdateModel>
    {
        public TrainingLevelController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(LevelReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           LevelUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Levels.ToString());
            Cache.Remove(CacheKey.Levels.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]       
        [ProducesResponseType(typeof(LevelReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           LevelCreateModel model)
        {
            var search = Query<Level>.Create(x => x.Title.ToUpper().Contains(model.Title.ToUpper()));
            var query = new SingleQuery<Level>(search);
            var isExists = await FirstOrDefaultQuery(query, cancellationToken).ConfigureAwait(false);
            if (isExists.Data.Id != Guid.Empty) throw new DomainException(422, $"Title: '{model.Title}' is already exists.");
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Levels.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(LevelReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Levels.ToString());
            Cache.Remove(CacheKey.Levels.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LevelReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var command = new LevelReadCommand(id);           
            Task<LevelReadModel> readModel() => Mediator.Send(command, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Levels.ToString() + id}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(EntityListResult<LevelReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
           
            var query = new EntityQuery<Core.Data.Entities.Level>();
            Task<EntityListResult<LevelReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Levels.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("GetAllLevelByCourseId")]
        [ProducesResponseType(typeof(EntityListResult<LevelReadModel>), 200)]
        public async Task<IActionResult> GetAllLevelByCourseId(CancellationToken cancellationToken, Guid CourseId)
        {
            var search = Query<TrainingBuildCourse>.Create(x => x.CourseId == CourseId);
            var query = new EntityQuery<TrainingBuildCourse>(search, 1, int.MaxValue, string.Empty);
            var command = new LevelCourseReadCommand<TrainingBuildCourse>(query, CourseId);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
    }

}