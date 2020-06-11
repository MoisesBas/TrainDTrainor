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
using TrainDTrainorV2.Core.Domain.CommitteeQuestion.Models;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
   // [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Committee Question")]
    [Route("api/committeequestion")]    
    public class CommitteeQuestionController : MediatorCommandControllerBase<Guid,
        CommitteeQuestion,
        CommitteeQuestionReadModel,
        CommitteeQuestionCreateModel,
        CommitteeQuestionUpdateModel>
    {
        public CommitteeQuestionController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(CommitteeQuestionReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
          CommitteeQuestionUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.CommitteeQuestions.ToString());
            Cache.Remove(CacheKey.CommitteeQuestions.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]
        [ProducesResponseType(typeof(CommitteeQuestionReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           CommitteeQuestionCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.CommitteeQuestions.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(CommitteeQuestionReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.CommitteeQuestions.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommitteeQuestionReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {           
            Task<CommitteeQuestionReadModel> readModel() => GetQuery(id, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.CommitteeQuestions.ToString() + id}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("GetAllCommitteeQuestion")]
        [ProducesResponseType(typeof(CommitteeQuestionReadModel), 200)]
        public async Task<IActionResult> GetAllCommitteeQuestion(CancellationToken cancellationToken)
        {
            var search = Query<CommitteeQuestion>.Create(x => x.Name.Contains(string.Empty));
            var query = new EntityQuery<CommitteeQuestion>(search, 1, 20, string.Empty);
            Task<EntityListResult<CommitteeQuestionReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.CommitteeQuestions.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
            
            
        }
    }
}