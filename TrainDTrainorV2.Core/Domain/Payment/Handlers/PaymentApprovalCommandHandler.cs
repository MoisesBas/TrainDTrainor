using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class PaymentApprovalCommandHandler : RequestHandlerBase<PaymentApprovalCommand<Guid, PaymentTransaction, PaymentReadModel>, PaymentReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        public IMediator Mediator { get; set; }
        public PaymentApprovalCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
             IConfigurationProvider configurationProvider,
            IMapper mapper, IMediator mediator) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
            Mediator = mediator;
        }

        protected override async Task<PaymentReadModel> ProcessAsync(PaymentApprovalCommand<Guid, PaymentTransaction, PaymentReadModel> message, CancellationToken cancellationToken)
        {
            var command = new EntityIdentifierQuery<Guid, PaymentTransaction, PaymentReadModel>(message.Id, message.Principal);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            if (result == null)
                throw new DomainException(422, $"Payment Id '{message.Id}' not found.");

            if (result.Status != message.PaymentStatus)
            {
                var commandCourse = new EntityIdentifierQuery<Guid, TrainingCourse, CourseReadModel>(result.CourseId.Value, message.Principal);
                var resultCourse = await Mediator.Send(commandCourse, cancellationToken).ConfigureAwait(false);

                if (resultCourse == null)
                    throw new DomainException(422, $"Course Id '{result.CourseId}' not found.");

                if (resultCourse.MaxAttendee == resultCourse.NoAttendee)
                    throw new DomainException(422, $"Course '{resultCourse.Title}' is already full.");
                var mapCourse = _mapper.Map<CourseUpdateModel>(resultCourse);
                mapCourse.MaxAttendee = mapCourse.MaxAttendee - 1;
                mapCourse.NoAttendee = mapCourse.NoAttendee + 1;

                var updateCourse = new EntityUpdateCommand<Guid, TrainingCourse, CourseUpdateModel, CourseReadModel>(resultCourse.Id, mapCourse, message.Principal);

                var mediatorCourse = await Mediator.Send(updateCourse, cancellationToken)
                    .ConfigureAwait(false);

                result.Status = message.PaymentStatus;
                var map = _mapper.Map<PaymentUpdateModel>(result);
                var update = new EntityUpdateCommand<Guid, PaymentTransaction, PaymentUpdateModel, PaymentReadModel>(message.Id, map, message.Principal);

                result = await Mediator.Send(update, cancellationToken).ConfigureAwait(false);

                var history = _mapper.Map<PaymentTransactionHistory>(result);
                var dbSetHistory = _dataContext.Set<Data.Entities.PaymentTransactionHistory>();
                await dbSetHistory.AddAsync(history, cancellationToken).ConfigureAwait(false);
                await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                var mapAttendee = _mapper.Map<TrainingBuildCoursesAttendeeCreatedModel>(result);

                var courseAttendee = new EntityCreateCommand<Core.Data.Entities.TrainingBuildCourseAttendee, TrainingBuildCoursesAttendeeCreatedModel, TrainingBuildCoursesAttendeeReadModel>(mapAttendee,message.Principal);

                var resultCourseAttendee = await Mediator.Send(courseAttendee, cancellationToken).ConfigureAwait(false);
            }
            return result;
        }
    }
}
