using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Role.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE ROLES")]
    [Route("api/roles")]    
    public class SystemRolesController : MediatorCommandControllerBase<Guid,
        Core.Data.Entities.Role,
        RoleReadModel,
        RoleCreateModel,
        RoleUpdateModel>
    {
        public SystemRolesController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(RoleReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           RoleUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Roles.ToString());
            Cache.Remove(CacheKey.Roles.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]
        [ProducesResponseType(typeof(RoleReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           RoleCreateModel model)
        {
            var search = Query<Core.Data.Entities.Role>.Create(x => x.Name.ToUpper().Contains(model.Name.ToUpper()));
            var query = new SingleQuery<Core.Data.Entities.Role>(search);
            var isExists = await FirstOrDefaultQuery(query, cancellationToken).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(isExists.Data.Name)) throw new DomainException(422, $"Role: '{model.Name}' is already exists.");
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Roles.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(RoleReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Roles.ToString());
            Cache.Remove(CacheKey.Roles.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

       
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(EntityListResult<RoleReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new EntityQuery<Core.Data.Entities.Role>();
            Task<EntityListResult<RoleReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Roles.ToString()}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
            
        }
    }
}