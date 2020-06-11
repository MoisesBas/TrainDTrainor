using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Commands;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using TrainDTrainorV2.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.IO;
using TrainDTrainorV2.Core.Services.Caching;
using TrainDTrainorV2.CommandQuery.Queries;

namespace TrainDTrainorV2.API.Controllers
{
    public abstract class MediatorCommandControllerBase<TKey, TEntity, TReadModel, TCreateModel, TUpdateModel>
        : MediatorQueryControllerBase<TKey, TEntity, TReadModel>
        where TEntity : class, new()
    {
        protected MediatorCommandControllerBase(IMediator mediator
            ) : base(mediator)
        {
        }

        protected MediatorCommandControllerBase(IMediator mediator,
            IAppCache cache) : base(mediator,cache)
        {
        }

        protected MediatorCommandControllerBase(IMediator mediator,
            IGridFsService gridFsService) : base(mediator,gridFsService)
        {
        }
        protected virtual IActionResult ObjectResult(TReadModel readModel,
           int status)
        {
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }
        protected virtual IActionResult ObjectResultWithFile(TReadModel readModel,string file,
           int status)
        {
            return new OkObjectResult(new
            {
                Data = readModel,
                File = file,
                Status = StatusCodes.Status200OK
            });
        }
        protected virtual async Task<TReadModel> CreateCommand(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityCreateCommand<TEntity, TCreateModel, TReadModel>(createModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
        protected virtual async Task<IEnumerable<TReadModel>> BulkCreateCommand(IEnumerable<TCreateModel> createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityBulkCreateCommand<TEntity, TCreateModel, TReadModel>(createModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }
        protected virtual async Task<IEnumerable<TReadModel>> BulkDeleteCommand(IEnumerable<TUpdateModel> deleteModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityBulkDeleteCommand<TEntity, TUpdateModel, TReadModel>(deleteModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }
        protected virtual async Task<TReadModel> UpdateCommand(TKey id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>(id, updateModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }

        protected virtual async Task<TReadModel> PatchCommand(TKey id, JsonPatchDocument<TEntity> jsonPatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityPatchCommand<TKey, TEntity, TReadModel>(id, jsonPatch, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }

        protected virtual async Task<TReadModel> DeleteCommand(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityDeleteCommand<TKey, TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
        protected virtual async Task<bool> SingleDeleteCommand(SingleQuery<TEntity> entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityDeleteQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }
        protected virtual async Task<EntitySingleResult<TReadModel>> SingleQueryCommand(SingleQuery<TEntity> entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntitySingleQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
        protected virtual string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        protected virtual Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".mp4", "video/mp4" }
            };
        }
    }
}