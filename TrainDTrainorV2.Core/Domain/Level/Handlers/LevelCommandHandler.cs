using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Level.Commands;
using TrainDTrainorV2.Core.Domain.Level.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.Level.Handlers
{
    public class LevelCommandHandler : RequestHandlerBase<LevelReadCommand, LevelReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public LevelCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IMemoryCache cache) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _cache = cache;
            _mapper = mapper;
        }
        protected override async Task<LevelReadModel> ProcessAsync(LevelReadCommand message, CancellationToken cancellationToken)
        {
            var readLevel = new LevelReadModel();
            var level = await _dataContext.Levels
                                          .Include(x => x.LevelQuestions)
                                          .Include(x => x.LevelVideos)
                                          .Include(x => x.Subjects)
                                          .GetByKeyAsync(message.Id)
                .ConfigureAwait(false);
            if (level != null)
            {
                readLevel = _mapper.Map<LevelReadModel>(level);
                var ids = level.LevelVideos.Select(x => x.Id).ToArray();
                if (ids.Count() > 0)
                {
                    var videos = _dataContext.LevelVideoPicFiletable
                                                   .Where(x => ids.Contains(x.Id));
                    _mapper.Map(videos, readLevel.Videos);
                }
            }

            if (level == null)
                throw new DomainException(422, $"Level with id '{message.Id}' not found.");         
            return readLevel;
        }
    }
}
