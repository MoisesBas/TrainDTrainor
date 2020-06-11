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
using TrainDTrainorV2.Core.Domain.TrainingExperience.Commands;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.API.Controllers
{
    [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Courses")]
    [Route("api/trainingexperience")]
    public class TrainingExperienceController : MediatorCommandControllerBase<Guid,
        TrainingExperience,
        TrainingExperienceReadModel,
        TrainingExperienceCreatedModel,
        TrainingExperienceUpdatedModel>
    {
        public TrainingExperienceController(IMediator mediator
            ) : base(mediator)
        {
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(TrainingExperienceReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           TrainingExperienceUpdatedModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(TrainingExperienceReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
          TrainingExperienceCreatedModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(TrainingExperienceReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("GetTrainingExperienceByProfileId")]
        [ProducesResponseType(typeof(EntityListResult<TrainingExperienceReadModel>), 200)]
        public async Task<IActionResult> GetTrainingExperienceByProfileId(CancellationToken cancellationToken,
           Guid profileId)
        {            
            var search = Query<TrainingExperience>.Create(x => x.UserProfileId == profileId);
            var query = new EntityQuery<TrainingExperience>(search, 1, int.MaxValue, null);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }


    }
}