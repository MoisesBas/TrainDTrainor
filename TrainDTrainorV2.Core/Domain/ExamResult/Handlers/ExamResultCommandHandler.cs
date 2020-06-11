using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Extensions;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.ExamResult.Commands;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Handlers
{   
    public class ExamResultCommandHandler : RequestHandlerBase<ExamResultCommand<ExamResultCreateModel>, IEnumerable<ExamResultReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        public ExamResultCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IConfigurationProvider configurationProvider
           ) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<IEnumerable<ExamResultReadModel>> ProcessAsync(ExamResultCommand<ExamResultCreateModel> message, CancellationToken cancellationToken)
        {
           var exam = await _dataContext.TrainingExams
                                        .ProjectTo<TrainingExamReadModel>(_configurationProvider)
                                        .ToListAsync(cancellationToken)
                                        .ConfigureAwait(false);
            if(exam.Count == 0) throw new DomainException(422, $"Training Exam is null., Please Create question in exam module.,");
            var dbSet = _dataContext.Set<Data.Entities.TraineeExamResult>();

            foreach (var item in exam)
            {
               var map =  _mapper.Map(item, message.Exam);
                dbSet.AddIfNotExists(x => new { x.Id, x.QuestionId, x.CourseId, x.UserId }, _mapper.Map<TraineeExamResult>(map));
            }
          var result =   await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            var examresult = _dataContext.ExamResults.Include(x => x.Question)
                .Where(x=>x.UserId == message.Exam.UserId && x.CourseId == message.Exam.CourseId);

            return _mapper.Map<IEnumerable<ExamResultReadModel>>(examresult);            
        }


    }
}
