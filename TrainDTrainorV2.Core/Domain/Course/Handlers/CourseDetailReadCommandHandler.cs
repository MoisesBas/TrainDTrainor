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
using TrainDTrainorV2.Core.Domain.Course.Commands;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Handlers
{
   public class CourseDetailReadCommandHandler : RequestHandlerBase<CourseDetailReadCommand, CourseReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public CourseDetailReadCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;            
            _mapper = mapper;
        }

        protected override Task<CourseReadModel> ProcessAsync(CourseDetailReadCommand message, CancellationToken cancellationToken)
        {
            var course = _dataContext.TrainingCourse
                         .Include(x => x.CourseMaterials);
            return null;
                          
        }
    }
}
