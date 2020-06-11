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
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserCommandHandler : RequestHandlerBase<UserCommand, EntityListResult<UserReadModel>>
        {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private static readonly Lazy<IReadOnlyCollection<UserReadModel>> _emptyList = new Lazy<IReadOnlyCollection<UserReadModel>>(() => new List<UserReadModel>().AsReadOnly());
        public UserCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IConfigurationProvider configurationProvider) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }
        protected override async Task<EntityListResult<UserReadModel>> ProcessAsync(UserCommand message, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users                      
                       .Include(x => x.UserProfiles)
                       .ThenInclude(x=>x.PaymentTransactions)
                       .ThenInclude(y=>y.Course)
                       .Include(x=>x.UserRoles)
                       .ProjectTo<UserReadModel>(_configurationProvider)
                       .ToListAsync(cancellationToken);
            user = user.Where(x => x.Roles.UserType == (int)Enum.Roles.Trainee).ToList();
            if (user.Count == 0)
                return new EntityListResult<UserReadModel> { Data = _emptyList.Value };

            return new EntityListResult<UserReadModel>
            {
                Total = user.Count(),
                Data = user
            };


        }
    }
}
