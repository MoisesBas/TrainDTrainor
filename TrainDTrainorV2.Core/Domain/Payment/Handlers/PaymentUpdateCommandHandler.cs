using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class PaymentUpdateCommandHandler : RequestHandlerBase<PaymentUpdateCommand<PaymentUpdateModel, Guid>, PaymentReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public PaymentUpdateCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<PaymentReadModel> ProcessAsync(PaymentUpdateCommand<PaymentUpdateModel, Guid> message, CancellationToken cancellationToken)
        {
            if (message.Id == null) throw new DomainException(422, $"Id is null , Please try again.");
            var current = _dataContext.PaymentTransactions
                                .GetById(message.Id);

            current = current == null ? _mapper.Map<Data.Entities.PaymentTransaction>(message.Payment) :
                _mapper.Map(message.Payment, current);

            CreateResult result = new CreateResult();
            result = _mapper.Map<CreateResult>(_dataContext.PaymentPicFiletable.GetProfilePicId(current.FileId).FirstOrDefault());
            if (result == null) result = _dataContext.CreateDir(new PaymentTransactionPic() { Name = typeof(PaymentTransactionPic).Name, ParentPath = null });
            if (message.Payment.File != null)
            {
                if (message.Payment.File.Length > 0)
                {
                    var file = message.Payment.File;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var now = DateTimeOffset.Now;
                        var payment = new PaymentTransactionPic()
                        {
                            Name = Guid.NewGuid() + "_" + message.Payment.File.FileName,
                            File_stream = ms.ToArray(),
                            ParentPath = result.Path,
                            Creation_time = now,
                            Last_access_time = now,
                            Last_write_time = now,
                            Stream_id = current.FileId ?? Guid.NewGuid() 
                        };

                        result = _dataContext.UpdateFile(payment);
                    }
                    _mapper.Map(result, current);

                }
            }
            if (result != null)
            {
                if (current.Id == Guid.Empty)
                {
                    var dbSet = _dataContext.Set<Data.Entities.PaymentTransaction>();
                    await dbSet.AddAsync(current, cancellationToken).ConfigureAwait(false);
                }
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (status != 0)
                {
                    return _mapper.Map<PaymentReadModel>(current);
                }
                else
                {
                    Logger.LogWarning($"Unable to update user your payment, please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to update user your payment, please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to update user your payment, please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to update user your payment, please try again later or contact administrator.");
            }
        }
    }
}
