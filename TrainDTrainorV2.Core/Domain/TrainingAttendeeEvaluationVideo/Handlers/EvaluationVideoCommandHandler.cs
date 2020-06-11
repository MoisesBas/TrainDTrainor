﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Handlers
{
   

    public class EvaluationVideoCommandHandler : RequestHandlerBase<EvaluationVideoCommand<EvaluationVideoCreateModel>, EvaluationVideoReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public EvaluationVideoCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<EvaluationVideoReadModel> ProcessAsync(EvaluationVideoCommand<EvaluationVideoCreateModel> message, CancellationToken cancellationToken)
        {
            var records = new EvaluationVideoReadModel();
            var current = _mapper.Map<TraineeEvaluationVideo>(message.Model);
            var result = _mapper.Map<CreateResult>(_dataContext.FindFolder(new EvaluationVideoPic() { Name = typeof(EvaluationVideoPic).Name }));
            if (result == null) result = _dataContext.CreateDir(new EvaluationVideoPic() { Name = typeof(EvaluationVideoPic).Name, ParentPath = null });

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
                        result = _dataContext.CreateFile(new EvaluationVideoPic()
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
                var dbSet = _dataContext.Set<Data.Entities.TraineeEvaluationVideo>();
                await dbSet.AddAsync(current, cancellationToken).ConfigureAwait(false);
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                current = await _dataContext.TraineeEvaluationVideos
                    .SingleOrDefaultAsync(x => x.Id == current.Id, cancellationToken).ConfigureAwait(false);

                if (status != 0)
                {
                    _mapper.Map(current, records);
                    var videofile = _dataContext.EvaluationVideoPicFiletable.GetEvaluationVideoId(current.FileId);
                    _mapper.Map(videofile.FirstOrDefault(), records);
                    return records;

                }
                else
                {
                    Logger.LogWarning($"Unable to insert evaluation video, please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to insert evaluation video, please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to insert evaluation video, please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to insert evaluation video, please try again later or contact administrator.");
            }
        }
    }
}
