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
using TrainDTrainorV2.Core.Domain.Education.Commands;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.Core.Domain.Education.Handlers
{
    public class EducationReadCommandHandlers : RequestHandlerBase<EducationReadCommand<Core.Data.Entities.Education>, EntityListResult<EducationReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private static readonly Lazy<IReadOnlyCollection<EducationReadModel>> _emptyList = new Lazy<IReadOnlyCollection<EducationReadModel>>(() => new List<EducationReadModel>().AsReadOnly());
        private readonly IMapper _mapper;

        public EducationReadCommandHandlers(ILoggerFactory loggerFactory,
           TrainDTrainorContext dataContext,
            IConfigurationProvider configurationProvider,
           IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }
        protected override async Task<EntityListResult<EducationReadModel>> ProcessAsync(EducationReadCommand<Data.Entities.Education> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.EntityQuery;
            var query = entityQuery.Query.Filter(_dataContext.Educations);
            
            var total = await query
                        .CountAsync(cancellationToken)
                        .ConfigureAwait(false);

            if (total == 0) return new EntityListResult<EducationReadModel> { Data = _emptyList.Value };
           
            var result = await query
                    .Page(entityQuery.Page, entityQuery.PageSize)
                    .ProjectTo<EducationReadModel>(_configurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);

            return new EntityListResult<EducationReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }
    }
}
