using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Education")]
    [Route("api/education")]    
    public class EducationController : MediatorCommandControllerBase<Guid,
        Education,
        EducationReadModel,       
        EducationCreateModel,
        EducationUpdateModel>
    {
        public EducationController(IMediator mediator
            ) : base(mediator)
        {

        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(EducationReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           EducationUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(EducationReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           EducationCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(EducationReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpGet("GetEducationByProfileId")]
        [ProducesResponseType(typeof(EntityListResult<EducationReadModel>), 200)]
        public async Task<IActionResult> GetEducationByProfileId(
          Guid profileId,CancellationToken cancellationToken)
        {          
           
            var search = Query<Education>.Create(x => x.UserProfileId == profileId);
            var query = new EntityQuery<Education>(search, 1, int.MaxValue, null);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });

        }
        [HttpGet("GetEducationById")]
        [ProducesResponseType(typeof(EducationReadModel), 200)]
        public async Task<IActionResult> GetEducationById(
         Guid id, CancellationToken cancellationToken)
        {            
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });

        }
    }
}