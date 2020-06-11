using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Courses Attendee")]
    [Route("api/trainingbuildcourseattendee")]   
    public class TrainingBuildCoursesAttendeeController : MediatorCommandControllerBase<Guid,
        TrainingBuildCourseAttendee,
        TrainingBuildCoursesAttendeeReadModel,
        TrainingBuildCoursesAttendeeCreatedModel,
        TrainingBuildCoursesAttendeeUpdateModel>
    {
       
        public TrainingBuildCoursesAttendeeController(IMediator mediator, IAppCache cache        
           ) : base(mediator, cache)
        {
            
        }
        [HttpPut("BatchInsert")]
        [ProducesResponseType(typeof(EntityListResult<TrainingBuildCoursesAttendeeReadModel>), 200)]
        public async Task<IActionResult> BulkInsert(CancellationToken cancellationToken,IEnumerable<TrainingBuildCoursesAttendeeCreatedModel> model)
        {
            var readModel = await BulkCreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove($"{CacheKey.TrainingCourses.ToString()}");
            return new OkObjectResult(new  {Data = readModel, Status = StatusCodes.Status200OK});
        }

        [HttpPut("BatchUpdate")]
        [ProducesResponseType(typeof(EntityListResult<TrainingBuildCoursesAttendeeReadModel>), 200)]
        public async Task<IActionResult> BulkUpdate(CancellationToken cancellationToken, IEnumerable<TrainingBuildCoursesAttendeeUpdateModel> model)
        {
            var readModel = await BulkDeleteCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove($"{CacheKey.TrainingCourses.ToString()}");
            return new OkObjectResult(new { Data = readModel, Status = StatusCodes.Status200OK });
        }
        [HttpGet("GetAllAttendeeByCourseId")]
        [ProducesResponseType(typeof(EntityListResult<TrainingBuildCoursesAttendeeReadModel>), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid CourseId)
        {
            var search = Query<TrainingBuildCourseAttendee>.Create(x => x.CourseId == CourseId);
            search = search.And(Query<TrainingBuildCourseAttendee>.Create(x => x.IsActive == true));
            var query = new EntityQuery<TrainingBuildCourseAttendee>(search, 1, int.MaxValue, string.Empty);           
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }

        [HttpPut("MapToOtherCourse")]
        [ProducesResponseType(typeof(EntityListResult<TrainingBuildCoursesAttendeeReadModel>), 200)]
        public async Task<IActionResult> MaptoOtherCourse(CancellationToken cancellationToken, 
            Guid Id, TrainingBuildCoursesAttendeeUpdateModel model)
        {
            var command = new MapToCourseCommand<TrainingBuildCoursesAttendeeUpdateModel>(model,Id);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            Cache.Remove($"{CacheKey.TrainingCourses.ToString()}");
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }

        [HttpGet("GetAllCourseByNotAttend")]
        [ProducesResponseType(typeof(EntityListResult<CourseReadModel>), 200)]
        public async Task<IActionResult> GetAllCourseByNotAttend(CancellationToken cancellationToken, Guid traineeId)
        {

            var search = Query<TrainingBuildCourseAttendee>.Create(x => x.AttendeeId == traineeId);
            search = search.And(Query<TrainingBuildCourseAttendee>.Create(x => x.IsActive == true));   
            var query = new EntityQuery<TrainingBuildCourseAttendee>(search, 1, int.MaxValue, string.Empty);    
            var readModel = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            var course = readModel.Data.Select(x => x.CourseId).ToArray();
            var searchCourse = Query<TrainingCourse>.Create(x => !course.Contains(x.Id));
            var queryCourse = new EntityQuery<TrainingCourse>(searchCourse,1,int.MaxValue,string.Empty);
            var command = new EntityListQuery<TrainingCourse, CourseReadModel>(queryCourse, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false); 
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
         
        }
    }
}