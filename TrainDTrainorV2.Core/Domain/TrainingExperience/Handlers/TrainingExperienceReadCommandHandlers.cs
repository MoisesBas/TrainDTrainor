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
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Commands;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Handlers
{
    public class TrainingExperienceReadCommandHandlers : RequestHandlerBase<TrainingExperienceReadCommand<Core.Data.Entities.TrainingExperience>, EntityListResult<TrainingExperienceReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private static readonly Lazy<IReadOnlyCollection<TrainingExperienceReadModel>> _emptyList = new Lazy<IReadOnlyCollection<TrainingExperienceReadModel>>(() => new List<TrainingExperienceReadModel>().AsReadOnly());
        private readonly IMapper _mapper;

        public TrainingExperienceReadCommandHandlers(ILoggerFactory loggerFactory,
           TrainDTrainorContext dataContext,
            IConfigurationProvider configurationProvider,
           IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }
        protected override async Task<EntityListResult<TrainingExperienceReadModel>> ProcessAsync(TrainingExperienceReadCommand<Data.Entities.TrainingExperience> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.EntityQuery;
            var query = entityQuery.Query.Filter(_dataContext.UserTrainingExperience);
            
            var total = await query
                        .CountAsync(cancellationToken)
                        .ConfigureAwait(false);

            if(total == 0) return new EntityListResult<TrainingExperienceReadModel> { Data = _emptyList.Value };

            var result = await query        
                    .Sort(entityQuery.Sort)
                    .Page(entityQuery.Page, entityQuery.PageSize)
                    .ProjectTo<TrainingExperienceReadModel>(_configurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);

            return new EntityListResult<TrainingExperienceReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }
    }
}
