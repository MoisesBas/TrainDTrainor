using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Domain.Authentication.Commands;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TrainDTrainorV2.Core.Options;

namespace TrainDTrainorV2.API.Controllers
{
    [Route("api/Token")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;       
        public TokenController(IMediator mediator, 
            IHttpContextAccessor httpContextAccessor,
            IOptions<MongoConnectionConfiguration> mongoConfiguration)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;                    
        }       
        [HttpPost("Authenticate")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public async Task<IActionResult> Authenticate(CancellationToken cancellationToken, TokenRequest tokenRequest)
        {
            try
            {
                var userAgent = Request.UserAgent();
                var command = new AuthenticateCommand(userAgent, tokenRequest);
                var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

                return new OkObjectResult(new
                {
                    Data = result,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AuthenticationException authenticationException)
            {
                var error = new TokenError
                {
                    Error = authenticationException.ErrorType,
                    ErrorDescription = authenticationException.Message
                };
                return BadRequest(error);
            }

        }
    }
}
