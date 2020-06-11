using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Country.Models;
using TrainDTrainorV2.Core.Domain.ExamResult.Commands;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;
using TrainDTrainorV2.Core.Domain.Role.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE COUNTRY")]
    [Route("api/examresults")]    
    public class TraineeExamResultController : MediatorCommandControllerBase<Guid,
        Core.Data.Entities.TraineeExamResult,
        ExamResultReadModel,
        ExamResultCreateModel,
        ExamResultUpdateModel>
    {
        public TraineeExamResultController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }
        
        [HttpPut("TakeExam")]
        [ProducesResponseType(typeof(IEnumerable<ExamResultReadModel>), 200)]
        public async Task<IActionResult> TakeExam(CancellationToken cancellationToken,
           ExamResultCreateModel model)
        {
            var command = new ExamResultCommand<ExamResultCreateModel>(model);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
                   
        }
        [HttpPut("UpdateExam")]
        [ProducesResponseType(typeof(IEnumerable<ExamResultReadModel>), 200)]
        public async Task<IActionResult> UpdateExam(CancellationToken cancellationToken,
           IEnumerable<ExamResultUpdateModel> model)
        {
            var command = new ExamResultCommand<IEnumerable<ExamResultUpdateModel>>(model);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });

        }
        [HttpPut("getmyexam")]
        [ProducesResponseType(typeof(IEnumerable<ExamResultReadModel>), 200)]
        public async Task<IActionResult> GetMyExam(CancellationToken cancellationToken,
          Guid userId, Guid courseId)
        {            
            var search = Query<TraineeExamResult>.Create(x => x.UserId.Equals(userId) && x.CourseId.Equals(courseId));
            var query = new EntityQuery<TraineeExamResult>(search, 1, int.MaxValue, null);
            var result = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });

        }

    }
}