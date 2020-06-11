using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Courses")]
    [Route("api/buildcourses")]   
    public class TrainingBuildCourseController : MediatorCommandControllerBase<Guid,
        TrainingBuildCourse,
        TrainingBuildCourseReadModel,
        TrainingBuildCourseCreatedModel,
        TrainingBuildCourseUpdateModel>
    {
        public TrainingBuildCourseController(IMediator mediator, IAppCache cache
            ) : base(mediator)
        {
        }
        
        [HttpPut("BatchInsert")]
        [ProducesResponseType(typeof(EntityListResult<TrainingBuildCourseReadModel>), 200)]
        public async Task<IActionResult> BulkInsert(CancellationToken cancellationToken,
           IEnumerable<TrainingBuildCourseCreatedModel> model)
        {          
            var command = new TrainingBuildCourseBulkInsertCommand<TrainingBuildCourse, TrainingBuildCourseCreatedModel, TrainingBuildCourseReadModel>(model, null);
            var readModel = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);           
            return new OkObjectResult(new {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(TrainingBuildCourseReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           TrainingBuildCourseCreatedModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(TrainingBuildCourseReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }        
    }
}