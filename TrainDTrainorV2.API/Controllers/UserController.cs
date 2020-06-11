using System;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Authentication.Commands;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TrainDTrainorV2.Core.Services;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Services.Caching;
using TrainDTrainorV2.Core.Domain.User.Models;
using Microsoft.EntityFrameworkCore;
using TrainDTrainorV2.Core.Data;
using System.Linq;
using AutoMapper;
using TrainDTrainorV2.Core.Domain.UserRole.Models;
using System.Collections.Generic;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE User")]
    [Route("api/User")]
    public class UserController : MediatorCommandControllerBase<Guid, User, 
        UserReadModel,        
        UserCreateModel, 
        UserUpdateModel>
    {
        private readonly TrainDTrainorContext _context;
        
        public UserController(IMediator mediator,
            TrainDTrainorContext context,            
            IAppCache cache) : base(mediator,cache)
        {
            _context = context;            
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public async Task<IActionResult> Login(CancellationToken cancellationToken, TokenRequest tokenRequest)
        {
            var userAgent = Request.UserAgent();           
            var command = new AuthenticateCommand(userAgent, tokenRequest);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new  OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }

        //[Authorize]
        [AllowAnonymous]
        [HttpPost("verifyotp")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> VerifyOTP(CancellationToken cancellationToken,UserVerifyOTPModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserVerifyOTPModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(new
            {
                Data = result != null ? true :false,
                Status = StatusCodes.Status200OK
            });            
        }

        [Authorize] 
        [HttpPut("resetotp")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> ResetOTP(CancellationToken cancellationToken, UserSendOTPModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserSendOTPModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(new
            {
                Data = result != null ? true : false,
                Status = StatusCodes.Status200OK
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, UserRegisterModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserRegisterModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            var tokenRequest = new TokenRequest
            {
                GrantType = "password",
                ClientId = "TrainDTrainorUI",
                UserName = model.EmailAddress,
                Password = model.Password                
            };
            var authenticateCommand = new AuthenticateCommand(userAgent, tokenRequest);
            var tokenResult = await Mediator.Send(authenticateCommand, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = tokenResult,
                Status = StatusCodes.Status200OK
            });
        }
      

        [AllowAnonymous]
        [HttpPost("forgetPassword")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> ForgotPassword(CancellationToken cancellationToken, UserForgotPasswordModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserForgotPasswordModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }

        [AllowAnonymous]
        [HttpPost("resetPassword")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> ResetPassword(CancellationToken cancellationToken, UserResetPasswordModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserResetPasswordModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, UserUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, JsonPatchDocument<User> jsonPatch)
        {
            var readModel = await PatchCommand(id, jsonPatch, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, Guid id)
        {
            var search = Query<User>.Create(x => x.Id.Equals(id));
            search.IncludeProperties = @"UserProfiles,UserRoles,ExamResults,UserTrainings";
            var query = new SingleQuery<User>(search);
            var readModel = await SingleDeleteCommand(query, cancellationToken).ConfigureAwait(false);
            return Ok(readModel);
        }


        [AllowAnonymous]
        [HttpGet("getalltrainee")]
        [ProducesResponseType(typeof(EntityListResult<UserReadModel>), 200)]
        public async Task<IActionResult> GetallApprovedTrainee(Guid courseid, CancellationToken cancellationToken)
        {
            var search = Query<User>.Create(x => x.DisplayName.ToUpper().Contains(string.Empty));
            var query = new EntityQuery<Core.Data.Entities.User>(search, 1, int.MaxValue, string.Empty);
            var command = new UserPaidCommand<Core.Data.Entities.User>(query, courseid);
            var readModel = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            var result = Cache.GetOrAdd($"{CacheKey.NotInCourse.ToString()}",
                s => readModel);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }
        [AllowAnonymous]
        [HttpGet("getalluser")]
        [ProducesResponseType(typeof(EntityListResult<UserReadModel>), 200)]
        public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
        {
            var command = new UserCommand();
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = result,
                Status = StatusCodes.Status200OK
            });
        }



        [AllowAnonymous]
        [HttpPut("AddUser")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> AddUser(CancellationToken cancellationToken, UserAddModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserAddModel>(model, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return new OkObjectResult(new
            {
                Data = result != null ? true : false,
                Status = StatusCodes.Status200OK
            });
        }


    }
}