using System;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Extensions;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Handlers
{

    public class LevelBestVideoCommandHandler : RequestHandlerBase<LevelBestVideoCommand<LevelBestVideoCreateModel>, LevelBestVideoReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public LevelBestVideoCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<LevelBestVideoReadModel> ProcessAsync(LevelBestVideoCommand<LevelBestVideoCreateModel> message, CancellationToken cancellationToken)
        {
            var records = new LevelBestVideoReadModel();
            var current = _mapper.Map<LevelVideo>(message.Model);
            var result = _mapper.Map<CreateResult>(_dataContext.FindFolder(new LevelVideoPic() { Name = typeof(LevelVideoPic).Name }));
            if (result == null) result = _dataContext.CreateDir(new LevelVideoPic() { Name = typeof(LevelVideoPic).Name, ParentPath = null });

            if (message.Model.File != null)
            {
                if (message.Model.File.Length > 0)
                {
                    var file = message.Model.File;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var now = DateTimeOffset.Now;
                        result = _dataContext.CreateFile(new LevelVideoPic()
                        {
                            Name = Guid.NewGuid() + "_" + message.Model.File.FileName,
                            File_stream = ms.ToArray(),
                            ParentPath = result.Path,
                            Creation_time = now,
                            Last_access_time = now,
                            Last_write_time = now
                        });
                        _mapper.Map(result, current);
                    }
                }
            }
            if (result != null)
            {
                var dbSet = _dataContext.Set<Data.Entities.LevelVideo>();
                await dbSet.AddAsync(current, cancellationToken).ConfigureAwait(false);             
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                current = await _dataContext.LevelVideos.Include(x => x.Level)
                    .SingleOrDefaultAsync(x => x.Id == current.Id,cancellationToken).ConfigureAwait(false);

                if (status != 0)
                {
                    _mapper.Map(current, records);
                    var videofile = _dataContext.LevelVideoPicFiletable.GetLevelVidoePicId(current.FileId);
                    _mapper.Map(videofile.FirstOrDefault(), records);               
                    return records;
                }
                else
                {
                    Logger.LogWarning($"Unable to insert level best practise video, please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to insert level best practise video, please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to insert level best practise video, please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to insert level best practise video, please try again later or contact administrator.");
            }
        }
    }
}
