using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Commands;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.CommandQuery.Queries;

namespace TrainDTrainorV2.Core.Domain.Course.Handlers
{
   public class CourseReadCommandHandler : RequestHandlerBase<CourseReadCommand, CourseReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CourseReadCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
             IMediator mediator) : base(loggerFactory)
        {
            _dataContext = dataContext;            
            _mapper = mapper;
            _mediator = mediator;
        }

        protected override async Task<CourseReadModel> ProcessAsync(CourseReadCommand message, CancellationToken cancellationToken)
        {
            var coursetrainee = _dataContext.TrainingBuildCourseAttendees
                .GetCourseByAttendeeId(message.TraineeId);

            var courses = await _dataContext.TrainingCourse.ToListAsync();

            return null;
        }
        
    }
}
