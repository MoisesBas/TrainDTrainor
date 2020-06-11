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
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
   // [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Training Level Subject")]
    [Route("api/levelsubject")]    
    public class TrainingLevelSubjectController : MediatorCommandControllerBase<Guid,
        LevelSubject,
        LevelSubjectReadModel,
        LevelSubjectCreateModel,
        LevelSubjectUpdateModel>
    {
        public TrainingLevelSubjectController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(LevelSubjectReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
          LevelSubjectUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);           
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]
        [ProducesResponseType(typeof(LevelSubjectReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           LevelSubjectCreateModel model)
        {
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);            
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(LevelSubjectReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);           
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LevelQuestionReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);           
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("GetAllLevelSubjectByLevelId")]
        [ProducesResponseType(typeof(LevelQuestionReadModel), 200)]
        public async Task<IActionResult> GetAllQuestionByLevelId(CancellationToken cancellationToken, Guid levelId)
        {
            var search = Query<LevelSubject>.Create(x => x.LevelId == levelId);
            var query = new EntityQuery<LevelSubject>(search, 1, 20, string.Empty);
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);         
            return new OkObjectResult(new { Data = readModel, Status = StatusCodes.Status200OK });
            
        }
    }
}