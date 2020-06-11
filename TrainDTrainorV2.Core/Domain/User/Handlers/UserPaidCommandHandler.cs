using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Security;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using TrainDTrainorV2.CommandQuery.Queries;
using System.Collections.Generic;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{

    public class UserPaidCommandHandler : RequestHandlerBase<UserPaidCommand<Core.Data.Entities.User>, EntityListResult<UserReadModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private static readonly Lazy<IReadOnlyCollection<UserReadModel>> _emptyList = new Lazy<IReadOnlyCollection<UserReadModel>>(() => new List<UserReadModel>().AsReadOnly());
        public UserPaidCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IConfigurationProvider configurationProvider) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }
        protected override async Task<EntityListResult<UserReadModel>> ProcessAsync(UserPaidCommand<Core.Data.Entities.User> message, CancellationToken cancellationToken)
        {

            var user = await _dataContext.PaymentTransactions
                                         .Include(x => x.UserProfile)
                                         .ThenInclude(x => x.User)
                                         .Where(x => x.Status == (int)Enum.PaymentStatus.Approved)
                                         .ProjectTo<UserReadModel>(_configurationProvider)
                                         .ToListAsync(cancellationToken);
            if (user.Count() > 0)
            {                

                var attendee = await _dataContext.TrainingBuildCourseAttendees
                                                 .Include(x => x.Attendee)
                                                 .Where(x => x.CourseId == message.CourseId)
                                                 .ProjectTo<UserReadModel>(_configurationProvider)
                                                 .ToListAsync(cancellationToken);

                var result = attendee.Count() > 0 ?  user.Where(b => !attendee.Any(a => a.Id == b.Id)).ToList()
                    : user.ToList();

                return new EntityListResult<UserReadModel>
            {
                Data = result.AsReadOnly()
            };

            }
            return new EntityListResult<UserReadModel>
            {
                Data = _emptyList.Value
            };
        

        }
    }
}
