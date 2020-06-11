﻿using System;
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
using TrainDTrainorV2.Core.Domain.Achievement.Model;

namespace TrainDTrainorV2.API.Controllers
{
   [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Achievement")]
    [Route("api/Achievement")]
    [ApiController]
    public class AchievementController : MediatorCommandControllerBase<Guid,
        UserProfileAchievements,
        AchievementReadModel,       
        AchievementCreateModel,
        AchievementUpdateModel>
    {
        public AchievementController(IMediator mediator
            ) : base(mediator)
        {
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(AchievementReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
          AchievementUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Insert")]
        [ProducesResponseType(typeof(AchievementReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           AchievementCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpPut("Delete")]
        [ProducesResponseType(typeof(AchievementReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }
        [HttpGet("GetAchievementById")]
        [ProducesResponseType(typeof(AchievementReadModel), 200)]
        public async Task<IActionResult> GetAchievementById(
          Guid id, CancellationToken cancellationToken)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });

        }
        [HttpGet("GetAchievementByProfileId")]
        [ProducesResponseType(typeof(EntityListResult<AchievementReadModel>), 200)]
        public async Task<IActionResult> GetEducationByProfileId(
          Guid profileId, CancellationToken cancellationToken)
        {

            var search = Query<UserProfileAchievements>.Create(x => x.UserProfileId == profileId);
            var query = new EntityQuery<UserProfileAchievements>(search, 1, int.MaxValue, null);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });

        }
    }
}