using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.Role.Models;
using TrainDTrainorV2.Core.Domain.UserRole.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE ROLES")]
    [Route("api/userroles")]    
    public class UserRolesController : MediatorCommandControllerBase<Guid,
        Core.Data.Entities.UserRole,
        UserRoleReadModel,
        UserRoleCreateModel,
        UserRoleUpdateModel>
    {
        private readonly IMapper _mapper;
        public UserRolesController(IMediator mediator, IAppCache cache, IMapper mapper
           ) : base(mediator, cache)
        {
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("getallbyusertype")]
        [ProducesResponseType(typeof(EntityListResult<UserReadModel>), 200)]
        public async Task<IActionResult> GetAllbyUserType(int usertype, CancellationToken cancellationToken)
        {
            var search = Query<UserRole>.Create(x => x.UserType == usertype);
            search.IncludeProperties = "User";
            var query = new EntityQuery<Core.Data.Entities.UserRole>(search, 1, int.MaxValue, string.Empty);
            var result = await ListQuery(query, cancellationToken).ConfigureAwait(false);
            var user = _mapper.Map<IEnumerable<UserRoleReadModel>, IEnumerable<UserReadModel>>(result.Data);
            var output = new EntityListResult<UserReadModel> {
                Total = user.Count(),
                Data = user.ToList().AsReadOnly()
            };
            return new OkObjectResult(new
            {
                Data = output,
                Status = StatusCodes.Status200OK
            });
        }

        
    }
}