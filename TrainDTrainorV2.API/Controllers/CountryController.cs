using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Country.Models;
using TrainDTrainorV2.Core.Domain.Role.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE COUNTRY")]
    [Route("api/country")]    
    public class CountryController : MediatorCommandControllerBase<Guid,
        Core.Data.Entities.Country,
        CountryReadModel,
        CountryCreateModel,
        CountryUpdateModel>
    {
        public CountryController(IMediator mediator, IAppCache cache
           ) : base(mediator, cache)
        {
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(CountryReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id,
           CountryUpdateModel model)
        {
            var readModel = await UpdateCommand(id, model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Countries.ToString());
            Cache.Remove(CacheKey.Countries.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Insert")]
        [ProducesResponseType(typeof(CountryReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,
           CountryCreateModel model)
        {
            var search = Query<Core.Data.Entities.Country>.Create(x => x.Name.ToUpper().Contains(model.Name.ToUpper()));
            var query = new SingleQuery<Core.Data.Entities.Country>(search);
            var isExists = await FirstOrDefaultQuery(query, cancellationToken).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(isExists.Data.Name)) throw new DomainException(422, $"Country: '{model.Name}' is already exists.");
            var readModel = await CreateCommand(model, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Countries.ToString());
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

        [HttpPut("Delete")]
        [ProducesResponseType(typeof(CountryReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken,
           Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);
            Cache.Remove(CacheKey.Countries.ToString());
            Cache.Remove(CacheKey.Countries.ToString() + id);
            return ObjectResult(readModel, StatusCodes.Status200OK);
        }

       
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(EntityListResult<CountryReadModel>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var search = Query<Core.Data.Entities.Country>.Create(x => x.Name.ToUpper().Contains(string.Empty));
            var query = new EntityQuery<Core.Data.Entities.Country>(search,1,int.MaxValue,string.Empty);
            Task<EntityListResult<CountryReadModel>> readModel() => ListQuery(query, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Countries.ToString()}",readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            Task<CountryReadModel> readModel() => GetQuery(id, cancellationToken);
            var result = await Cache.GetOrAddAsync($"{CacheKey.Countries.ToString() + id}", readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
    }
}