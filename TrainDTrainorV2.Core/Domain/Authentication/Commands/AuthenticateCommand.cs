using System;
using TrainDTrainorV2.Core.Models;
using TrainDTrainorV2.Core.Security;
using MediatR;

namespace TrainDTrainorV2.Core.Domain.Authentication.Commands
{
    public class AuthenticateCommand : IRequest<TokenResponse>
    {
        public AuthenticateCommand(UserAgentModel userAgent, TokenRequest tokenRequest)
        {
            UserAgent = userAgent;
            TokenRequest = tokenRequest;
        }

        public TokenRequest TokenRequest { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}
