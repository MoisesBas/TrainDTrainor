using AutoMapper;
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
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class PaymentGetCommandHandler : RequestHandlerBase<PaymentGetCommand, PaymentReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public PaymentGetCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper,
            IMemoryCache cache) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _cache = cache;
            _mapper = mapper;
        }
        protected override async Task<PaymentReadModel> ProcessAsync(PaymentGetCommand message, CancellationToken cancellationToken)
        {
            if(!message.ProfileId.HasValue) throw new DomainException(422, $"Profile Id is null: '{message.ProfileId}', Please try again.");
            var payment = await _dataContext.PaymentTransactions
                                   .GetByUserProfileId(message.ProfileId.Value)
                                   .ConfigureAwait(false);
            if (payment == null) return _mapper.Map<PaymentReadModel>(payment);
            if(payment.FileId != Guid.Empty)
            {
                var pic = _dataContext.PaymentPicFiletable.GetProfilePicId(payment.FileId)
                                             .FirstOrDefault();
                var result = _mapper.Map<PaymentReadModel>(payment);
                var output = _mapper.Map(pic, result);
                return output;
            }
            return _mapper.Map<PaymentReadModel>(payment);
        }
    }
}
