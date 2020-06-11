using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Role.Models;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE ROLES")]
    [Route("api/exams")]    
    public class TrainingExamController : MediatorCommandControllerBase<Guid,
        Core.Data.Entities.TrainingExam,
        TrainingExamReadModel,
        TrainingExamCreateModel,
        TrainingExamUpdateModel>
    {
        public TrainingExamController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(TrainingExamReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           TrainingExamUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Exams.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]
        [ProducesResponseType(typeof(TrainingExamReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           TrainingExamCreateModel model)
        {
            var search = Query<Core.Data.Entities.TrainingExam>.Create(x => x.Question.ToUpper().Contains(model.Question.ToUpper()));
            var query = new SingleQuery<Core.Data.Entities.TrainingExam>(search);
            var isExists = await FirstOrDefaultQuery(query, cancellationToken).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(isExists.Data.Question)) throw new DomainException(422, $"Role: '{model.Question}' is already exists.");
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Exams.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(TrainingExamReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Exams.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

       
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(EntityListResult<TrainingExamReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new EntityQuery<Core.Data.Entities.TrainingExam>();
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);           
            var result = Cache.GetOrAdd($"{CacheKey.Exams.ToString()}",
                s => readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
    }
}