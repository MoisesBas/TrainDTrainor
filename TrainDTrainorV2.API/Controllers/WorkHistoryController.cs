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
using TrainDTrainorV2.Core.Domain.JobHistory.Models;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Work History")]
    [Route("api/WorkHistory")]    
    public class WorkHistoryController : MediatorCommandControllerBase<Guid, 
        UserProfileJobHistory,
        JobHistoryReadModel,        
        JobHistoryCreateModel,
        JobHistoryUpdateModel>
    {
        public WorkHistoryController(IMediator mediator
            ) : base(mediator)
        {

        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(JobHistoryReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           JobHistoryUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);           
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(JobHistoryReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           JobHistoryCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(JobHistoryReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("GetWorkHistoryByProfileId")]
        [ProducesResponseType(typeof(EntityListResult<JobHistoryReadModel>), 200)]
        public async Task<IActionResult> GetEducationByProfileId(CancellationToken cancellationToken,
          Guid profileId)
        {
            var search = Query<UserProfileJobHistory>.Create(x => x.UserProfileId == profileId);
            var query = new EntityQuery<UserProfileJobHistory>(search,1,int.MaxValue,null);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }
    }
}