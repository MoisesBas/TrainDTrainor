using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using Microsoft.Extensions.Logging;
using TrainDTrainorV2.Core.Domain.Training.Commands;
using TrainDTrainorV2.Core.Domain.Training.Models;
using Microsoft.Extensions.Caching.Memory;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using TrainDTrainorV2.Core.Data.Queries;

namespace TrainDTrainorV2.Core.Domain.Training.Handlers
{
    public class TrainingDetailCommandHandler : RequestHandlerBase<TrainingDetailCommand, TrainingDetailReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public TrainingDetailCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IMemoryCache cache) :base(loggerFactory)
        {
            _dataContext = dataContext;
            _cache = cache;
            _mapper = mapper;
        }
        protected override async Task<TrainingDetailReadModel> ProcessAsync(TrainingDetailCommand message, CancellationToken cancellationToken)
        {
            var training = await _dataContext.Training                
                .Include(x=>x.TrainingVideos)
                .Include(x=>x.Levels)
                .GetByKeyAsync(message.Id)
                .ConfigureAwait(false);
            if(training == null)
                throw new DomainException(422, $"Training with id '{message.Id}' not found.");

            var readModel = _mapper.Map<TrainingDetailReadModel>(training);   
            return readModel;
        }
    }
}
