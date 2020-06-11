using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Handlres
{
    public class TrainingBuildCourseDetailCommandHandler : RequestHandlerBase<TrainingBuildCourseDetailCommand, TrainingBuildCourseReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;       
        private readonly IMapper _mapper;        
        public TrainingBuildCourseDetailCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,           
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;           
            _mapper = mapper;
          
        }
        protected override async Task<TrainingBuildCourseReadModel> ProcessAsync(TrainingBuildCourseDetailCommand message, CancellationToken cancellationToken)
        {            
            var course = await _dataContext.TrainingBuildCourses
                          .Include(x => x.Course)
                          .Include(x => x.Level)
                          .Include(x => x.Question)
                          .GetByKeyAsync(message.Id)                          
                          .ConfigureAwait(false);            

            if (course == null) throw new DomainException(422, $"Course with id '{message.Id}' not found.");
            var readModel = _mapper.Map<TrainingBuildCourseReadModel>(course);
            return readModel;
        }
    }
}
