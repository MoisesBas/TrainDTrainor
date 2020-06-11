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
using TrainDTrainorV2.Core.Domain.TrainingVideos.Commands;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.Payment.Handlers
{
    public class TrainingVideoUpdateCommandHandler : RequestHandlerBase<TrainingVideoUpdateCommand<TrainingVideoUpdateModel, Guid>, TrainingVideoReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public TrainingVideoUpdateCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<TrainingVideoReadModel> ProcessAsync(TrainingVideoUpdateCommand<TrainingVideoUpdateModel, Guid> message, CancellationToken cancellationToken)
        {
            if (message.Id == null) throw new DomainException(422, $"Id is null , Please try again.");
            var current = await _dataContext.TrainingVideo.GetByKeyAsync
                                (message.Id);

            current = current == null ? _mapper.Map<Data.Entities.TrainingVideo>(message.TrainingVideo) :
                _mapper.Map(message.TrainingVideo, current);

            CreateResult result = new CreateResult();
            result = _mapper.Map<CreateResult>(_dataContext.FindFolder(new PaymentTransactionPic() { Name = typeof(PaymentTransactionPic).Name }));
            if (result == null) result = _dataContext.CreateDir(new PaymentTransactionPic() { Name = typeof(PaymentTransactionPic).Name, ParentPath = null });
            if (message.TrainingVideo.File != null)
            {
                if (message.TrainingVideo.File.Length > 0)
                {
                    var file = message.TrainingVideo.File;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var now = DateTimeOffset.Now;
                        var payment = new PaymentTransactionPic()
                        {
                            Name = Guid.NewGuid() + "_" + message.TrainingVideo.File.FileName,
                            File_stream = ms.ToArray(),
                            ParentPath = result.Path,
                            Creation_time = now,
                            Last_access_time = now,
                            Last_write_time = now,
                            Stream_id = current == null ? Guid.NewGuid() : current.FileId
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
                    var dbSet = _dataContext.Set<Data.Entities.TrainingVideo>();
                    await dbSet.AddAsync(current, cancellationToken).ConfigureAwait(false);
                }
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (status != 0)
                {
                    return _mapper.Map<TrainingVideoReadModel>(current);
                }
                else
                {
                    Logger.LogWarning($"Unable to update training video, please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to update training video, please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to update training video, please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to update training video, please try again later or contact administrator.");
            }
        }
    }
}
