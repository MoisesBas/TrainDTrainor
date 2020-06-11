using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.UserProfile.Commands;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.API.Controllers
{
    [Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE User Profile")]
    [Route("api/UseProfile")]
    public class UserProfileController : MediatorCommandControllerBase<Guid, UserProfile,
        UserProfileReadModel,      
        UserProfileCreateModel,
        UserProfileUpdateModel>
    {
        public UserProfileController(IMediator mediator,
            IGridFsService gridFsService) : base(mediator, gridFsService)
        {

        }
       
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(UserProfileReadModel), 200)]
        public async Task<IActionResult> GetById(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);
            return ObjectResult(readModel, StatusCodes.Status200OK);          
        }
       [AllowAnonymous]
        [HttpGet("GetByUserId")]
        [ProducesResponseType(typeof(UserProfileReadModel), 200)]
        public async Task<IActionResult> GetByUserId(CancellationToken cancellationToken, Guid id)
        {
            var command = new UserProfileGetCommand(id);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }

        [AllowAnonymous]
        [HttpPost("Update")]
        [ProducesResponseType(typeof(UserProfileReadModel), 200)]       
        public async Task<IActionResult> Update(CancellationToken cancellationToken,            
            [FromForm] UserProfileUpdateModel updateModel)
        {
            var command = new UserProfileCommand(updateModel);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);           
        }
    }
}