using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;
using TrainDTrainorV2.CommandQuery.Extensions;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Handlres
{

    public class TrainingBuildCourseBulkInsertCommandHandler : RequestHandlerBase<TrainingBuildCourseBulkInsertCommand<Data.Entities.TrainingBuildCourse, TrainingBuildCourseCreatedModel, TrainingBuildCourseReadModel>, IEnumerable<TrainingBuildCourseReadModel>>
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public TrainingBuildCourseBulkInsertCommandHandler(ILoggerFactory loggerFactory, DbContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<TrainingBuildCourseReadModel>> ProcessAsync(TrainingBuildCourseBulkInsertCommand<Data.Entities.TrainingBuildCourse, TrainingBuildCourseCreatedModel, TrainingBuildCourseReadModel> message, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<IEnumerable<Data.Entities.TrainingBuildCourse>>(message.Model);
            
            var dbSet = _context
                .Set<Data.Entities.TrainingBuildCourse>();

            foreach (var item in entity)
            {
                dbSet.AddIfNotExists(x => new { x.Id, x.LevelId, x.CourseId, x.QuestionId
            }, item);
            }
            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            var readModel = _mapper.Map<IEnumerable<TrainingBuildCourseReadModel>>(entity);
            return readModel;
        }
    }
}
