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
    public class ExamResultUpdateCommandHandler : RequestHandlerBase<ExamResultCommand<IEnumerable<ExamResultUpdateModel>>, IEnumerable<ExamResultReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        public ExamResultUpdateCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IConfigurationProvider configurationProvider
           ) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<IEnumerable<ExamResultReadModel>> ProcessAsync(ExamResultCommand<IEnumerable<ExamResultUpdateModel>> message, CancellationToken cancellationToken)
        {
            var exam = await _dataContext.TrainingExams
                                         .ToListAsync(cancellationToken)
                                         .ConfigureAwait(false);

            if (exam.Count == 0) throw new DomainException(422, $"Training Exam is null., Please Create question in exam module.,");
            var current = message.Exam.FirstOrDefault();
            var result = await _dataContext.ExamResults
                               .Where(x => x.CourseId.Equals(current.CourseId) &&
                               x.UserId.Equals(current.UserId)).ToListAsync();
            _mapper.Map(message.Exam, result.AsEnumerable());
            foreach (var item in exam)
            {
                foreach (var answer in message.Exam)
                {
                    if (item.Id == answer.QuestionId)
                    {
                        foreach (var r in result)
                        {
                            if (answer.Id == r.Id)
                            {
                                if (answer.Answer == item.Answer)
                                {

                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        //await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        //return _mapper.Map<IEnumerable<ExamResultReadModel>>(result);
       
    }


}

