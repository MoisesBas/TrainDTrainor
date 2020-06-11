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
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Courses Material")]
    [Route("api/trainingcoursematerial")]    
    public class TrainingCourseMaterialController : MediatorCommandControllerBase<Guid,
        CourseMaterial,
        CourseMaterialReadModel,
        CourseMaterialCreateModel,
        CourseMaterialUpdateModel>
    
    {
        public TrainingCourseMaterialController(IMediator mediator
            ) : base(mediator)
        {
        }
        [HttpPost("update")]
        [ProducesResponseType(typeof(CourseMaterialReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
          [FromForm] CourseMaterialUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPost("insert")]
        [ProducesResponseType(typeof(CourseMaterialReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
          [FromForm] CourseMaterialCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("delete")]
        [ProducesResponseType(typeof(CourseMaterialReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("getcoursematerial")]
        [ProducesResponseType(typeof(EntityListResult<CourseMaterialReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken, Guid courseId)
        {
            var search = Query<CourseMaterial>.Create(x => x.CourseId == courseId);
            var query = new EntityQuery<CourseMaterial>(search,1,20,string.Empty);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new { Data = readModel, Status = StatusCodes.Status200OK});
        }
    }
}