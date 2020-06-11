using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Handlers
{
    
    public class MapToCourseCommandHandler : RequestHandlerBase<MapToCourseCommand<TrainingBuildCoursesAttendeeUpdateModel>, EntitySingleResult<TrainingBuildCoursesAttendeeReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ISMSTemplateService _sMSTemplateService;
        private readonly IOptions<SMSConfiguration> _smsConfiguration;
        public IMediator _mediator { get; set; }
       
        public MapToCourseCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            ISMSTemplateService sMSTemplateService,
            IOptions<SMSConfiguration> smsConfiguration,
            IMediator mediator) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _sMSTemplateService = sMSTemplateService;
            _smsConfiguration = smsConfiguration;
            _mediator = mediator;
        }

        protected override async Task<EntitySingleResult<TrainingBuildCoursesAttendeeReadModel>> ProcessAsync(MapToCourseCommand<TrainingBuildCoursesAttendeeUpdateModel> message, CancellationToken cancellationToken)
        {
            
            var result = await GetAttendee(message,cancellationToken).ConfigureAwait(false);
            if(result.Data.CourseId == message.Course.CourseId)
                throw new DomainException(422, $"Trainee is already in in this course. Please select different course.");

            var resultQueryNewCourse = await GetNewCourse(message.Course.CourseId, cancellationToken).ConfigureAwait(false);

            if(resultQueryNewCourse.MaxAttendee == resultQueryNewCourse.NoAttendee)
                throw new DomainException(422, $"This course is already full. Please select other course or remove other trainee.,");
            
            var output = await ReAssignedToCourse(message.Course, cancellationToken).ConfigureAwait(false);
            var old = await UpdateOldAttendee(result.Data, message.Id, cancellationToken).ConfigureAwait(false);
            var resultNewCourse = await AddToNewCourse(resultQueryNewCourse, cancellationToken).ConfigureAwait(false);
            var resultOldCourse = await UpdateOldCourse(result.Data.Courses, cancellationToken).ConfigureAwait(false);
            var transaction = await PaymentTransaction(result.Data.AttendeeId, result.Data.CourseId, message.Course.CourseId, cancellationToken).ConfigureAwait(false);

            return new EntitySingleResult<TrainingBuildCoursesAttendeeReadModel> { Data = output };
        }

        private async Task<EntitySingleResult<TrainingBuildCoursesAttendeeReadModel>> GetAttendee(
            MapToCourseCommand<TrainingBuildCoursesAttendeeUpdateModel> message, CancellationToken cancellationToken)
        {
            var search = Query<Data.Entities.TrainingBuildCourseAttendee>.Create(x => x.Id == message.Id);
            search.IncludeProperties = "Course";

            var query = new SingleQuery<Data.Entities.TrainingBuildCourseAttendee>(search);
            var command = new EntitySingleQuery<Data.Entities.TrainingBuildCourseAttendee,
                TrainingBuildCoursesAttendeeReadModel>(query);

            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }
        private async Task<TrainingBuildCoursesAttendeeReadModel> UpdateOldAttendee(
            TrainingBuildCoursesAttendeeReadModel message,
            Guid id,
            CancellationToken cancellationToken)
        {
            var map = _mapper.Map<TrainingBuildCoursesAttendeeUpdateModel>(message);           
            var command = new EntityUpdateCommand<Guid,Data.Entities.TrainingBuildCourseAttendee,
                TrainingBuildCoursesAttendeeUpdateModel, TrainingBuildCoursesAttendeeReadModel>(id, map, null);
            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }
        private async Task<CourseReadModel> UpdateOldCourse(CourseReadModel result, CancellationToken cancellationToken)
        {
            var oldCourse = _mapper.Map<CourseUpdateModel>(result);
            oldCourse.MaxAttendee = oldCourse.MaxAttendee + 1;
            oldCourse.NoAttendee = oldCourse.NoAttendee - 1;          
            var commandOldCourse = new EntityUpdateCommand<Guid, Data.Entities.TrainingCourse, CourseUpdateModel, CourseReadModel>(result.Id, oldCourse, null);           
            return await _mediator.Send(commandOldCourse, cancellationToken).ConfigureAwait(false);
        }

        private async Task<CourseReadModel> GetNewCourse(Guid id, CancellationToken cancellationToken)
        {           
            var command = new EntityIdentifierQuery<Guid,TrainingCourse,CourseReadModel>(id, null);
            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }
        private async Task<CourseReadModel> AddToNewCourse(CourseReadModel resultQueryNewCourse,
             CancellationToken cancellationToken
            )
        {
            var mapnewCourse = _mapper.Map<CourseUpdateModel>(resultQueryNewCourse);
            mapnewCourse.MaxAttendee = mapnewCourse.MaxAttendee - 1;
            mapnewCourse.NoAttendee = mapnewCourse.NoAttendee + 1;

            var command = new EntityUpdateCommand<Guid, Data.Entities.TrainingCourse, CourseUpdateModel, CourseReadModel>(resultQueryNewCourse.Id, mapnewCourse, null);            
            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }

        private async Task<TrainingBuildCoursesAttendeeReadModel> ReAssignedToCourse(TrainingBuildCoursesAttendeeUpdateModel model, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<TrainingBuildCoursesAttendeeCreatedModel>(model);
            var command = new EntityCreateCommand<Data.Entities.TrainingBuildCourseAttendee, TrainingBuildCoursesAttendeeCreatedModel, TrainingBuildCoursesAttendeeReadModel>(map, null);

            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }

        private async Task<PaymentReadModel> PaymentTransaction(Guid attendeeId, Guid oldCourse,
            Guid newCourse, CancellationToken cancellationToken)
        {
            var search = Query<Data.Entities.PaymentTransaction>.Create(x => x.UserProfileId == attendeeId);
            search = search.And(Query<Data.Entities.PaymentTransaction>.Create(x => x.CourseId == oldCourse));
            var query = new SingleQuery<Data.Entities.PaymentTransaction>(search);
            var command = new EntitySingleQuery<Data.Entities.PaymentTransaction,
                PaymentReadModel>(query);

            var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
            var map = _mapper.Map<PaymentUpdateModel>(result.Data);
            map.CourseId = newCourse;

            var updatecommand = new EntityUpdateCommand<Guid, PaymentTransaction, PaymentUpdateModel, PaymentReadModel>(result.Data.Id, map, null);
            var output = await _mediator.Send(updatecommand, cancellationToken).ConfigureAwait(false);

            var historymap = _mapper.Map<PaymentHistoryCreateModel>(result.Data);
            var createcommand = new EntityCreateCommand<Data.Entities.PaymentTransactionHistory, PaymentHistoryCreateModel, PaymentHistoryReadModel>(historymap, null);
            await _mediator.Send(createcommand, cancellationToken).ConfigureAwait(false);
            return output;
        }
    }
}
