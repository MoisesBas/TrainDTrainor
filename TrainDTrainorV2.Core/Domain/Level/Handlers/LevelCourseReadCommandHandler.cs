using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Extensions;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.Level.Commands;
using TrainDTrainorV2.Core.Domain.Level.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Handlers
{

    public class LevelCourseReadCommandHandler : RequestHandlerBase<LevelCourseReadCommand<Core.Data.Entities.TrainingBuildCourse>, EntityListResult<LevelReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private static readonly Lazy<IReadOnlyCollection<LevelReadModel>> _emptyList = new Lazy<IReadOnlyCollection<LevelReadModel>>(() => new List<LevelReadModel>().AsReadOnly());
        private readonly IMapper _mapper;
        public LevelCourseReadCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
             IConfigurationProvider configurationProvider,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<EntityListResult<LevelReadModel>> ProcessAsync(LevelCourseReadCommand<Core.Data.Entities.TrainingBuildCourse> message, CancellationToken cancellationToken)
        {

            var entityQuery = message.EntityQuery;
            var query = await _dataContext.TrainingBuildCourses
                                          .Include(x => x.Course)
                                          .ThenInclude(x => x.Training)
                                          .Include(x => x.Question)
                                          .Include(x =>x.Level)
                                          .ThenInclude(x => x.Subjects)
                                          .Where(x => x.CourseId == message.CourseId)
                                          .ToListAsync(cancellationToken)
                                          .ConfigureAwait(false);

            var question = await _dataContext.LevelQuestions
                                    .Include(x => x.CourseLevel)
                                    .ToListAsync(cancellationToken)
                                    .ConfigureAwait(false);

            foreach(var origitem in question)
            {
                foreach(var subitem in query)
                {
                }
            }
            if (query.Count() == 0)
                return new EntityListResult<LevelReadModel> { Data = _emptyList.Value };
            var map = ExistsTraining(query);

            return new EntityListResult<LevelReadModel>
            {
                Total = map.Count(),
                Data = map.AsReadOnly()
            };

        }
        public List<LevelReadModel>ExistsTraining(List<Data.Entities.TrainingBuildCourse> query){
            var result = (from m in query
                          group m by m.LevelId into g
                          let l = g.FirstOrDefault().Level
                          select new
                          {
                              Id = g.Key.Value,
                              l.Title,
                              l.Description,
                              l.TrainingId,
                              l.Subjects,                           
                              Questions = g.Select(x => x.Question).Where(x => x.QuestionType == (int)Enum.QuestionType.Question).ToList(),
                              Strengths = g.Select(x => x.Question).Where(x => x.QuestionType == (int)Enum.QuestionType.Strength).ToList(),
                              Improvements = g.Select(x => x.Question).Where(x => x.QuestionType == (int)Enum.QuestionType.Improvements).ToList(),
                              Videos = l.LevelVideos,
                              l.Created,
                              l.CreatedBy,
                              l.Updated,
                              l.UpdatedBy,
                              l.RowVersion,
                          }).ToList();
            var map = _mapper.Map<List<LevelReadModel>>(result);
            return map;
        }
    }
}
