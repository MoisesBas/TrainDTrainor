using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Extensions;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class PaymentApprovalReadCommandHandler : RequestHandlerBase<PaymentApprovalReadCommand<PaymentDetailApproval>, EntityListResult<PaymentDetailApprovalModel>>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IConfigurationProvider _configurationProvider;
        private static readonly Lazy<IReadOnlyCollection<PaymentDetailApprovalModel>> _emptyList = new Lazy<IReadOnlyCollection<PaymentDetailApprovalModel>>(() => new List<PaymentDetailApprovalModel>().AsReadOnly());
        private readonly IMapper _mapper;
        public PaymentApprovalReadCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
             IConfigurationProvider configurationProvider,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<EntityListResult<PaymentDetailApprovalModel>> ProcessAsync(PaymentApprovalReadCommand<PaymentDetailApproval> message, CancellationToken cancellationToken)
        {

            var entityQuery = message.EntityQuery;

            

            var query = _dataContext.PaymentTransactions
                        .Include(x => x.UserProfile)
                        .ThenInclude(x => x.User)
                        .Include(x => x.Course)
                        .Where(x => x.Status == message.PaymentStatus);
            
                var total = await query
                    .CountAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (total == 0)
                    return new EntityListResult<PaymentDetailApprovalModel> { Data = _emptyList.Value };
                
                var result = await query
                        .Sort(entityQuery.Sort)
                        .Page(entityQuery.Page, entityQuery.PageSize)
                        .ProjectTo<PaymentDetailApprovalModel>(_configurationProvider)
                        .ToListAsync(cancellationToken)
                        .ConfigureAwait(false);

                return new EntityListResult<PaymentDetailApprovalModel>
                {
                    Total = total,
                    Data = result.AsReadOnly()
                };
           
        }
    }
}
