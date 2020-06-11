using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Services.PayFort.Command;

namespace TrainDTrainorV2.Core.Services.PayFort.Handler
{
   public class PayFortCommandHandler : RequestHandlerBase<PayFortCommand, PayFortResponse>
    {
        private readonly IOptions<PayFortOptionConfiguration> _payFortOptions;
        private readonly TrainDTrainorContext _dataContext;
        private HttpClient _httpClient;
        
        public PayFortCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IOptions<PayFortOptionConfiguration> payFortOptions):base(loggerFactory)
        {
            _payFortOptions = payFortOptions;
            _dataContext = dataContext;
            
        }

        protected override Task<PayFortResponse> ProcessAsync(PayFortCommand message, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
