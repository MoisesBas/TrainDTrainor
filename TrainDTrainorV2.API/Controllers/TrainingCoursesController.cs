using System;
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
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    // [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Courses")]
    [Route("api/courses")]  
    public class TrainingCoursesController : MediatorCommandControllerBase<Guid,
        TrainingCourse,
        CourseReadModel,
        CourseCreateModel,
        CourseUpdateModel>
    {
        public TrainingCoursesController(IMediator mediator, IAppCache cache
          ) : base(mediator, cache)
        {

        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(CourseReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           CourseUpdateModel model)
        {
            var readModel = await UpdateCommand(id,model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.TrainingCourses.ToString());
            Cache.Remove(CacheKey.TrainingCourses.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(CourseReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           CourseCreateModel model)
        {
            var search = Query<TrainingCourse>.Create(x => x.Title.ToUpper().Contains(model.Title.ToUpper()));
            var query = new SingleQuery<TrainingCourse>(search);
            var isExists = await FirstOrDefaultQuery(query, cancellationToken).ConfigureAwait(false);            
            if(!string.IsNullOrEmpty(isExists.Data.Title)) throw new DomainException(422, $"Course: '{model.Title}' is already exists.");
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.TrainingCourses.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
            
        }
        [HttpPut("Delete")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.TrainingCourses.ToString());
            Cache.Remove(CacheKey.TrainingCourses.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {            
            Task<CourseReadModel> readModel() => GetQuery(id, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.TrainingCourses.ToString() + id}", readModel);
            return new  OkObjectResult( new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
       
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(EntityListResult<CourseReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {            

            var query = new EntityQuery<TrainingCourse>();
            Task<EntityListResult<CourseReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.TrainingCourses.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }        
    }
}