using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.Core.Security;

namespace TrainDTrainorV2.Core.Tests
{
    public class MockPrincipal
    {
        static MockPrincipal()
        {
            Default = CreatePrincipal("test@mobadrah.ae", "Test User", Data.Constants.User.Member);
            GlobalAdmin = CreatePrincipal("support@mobadrah.ae", "TrainDTrainor Support", Data.Constants.User.Support, true);
        }


        public static IPrincipal Default { get; }

        public static IPrincipal GlobalAdmin { get; }


        public static ClaimsPrincipal CreatePrincipal(string email, string name, Guid userId, bool isGlobalAdmin = false)
        {
            var claimsIdentity = new ClaimsIdentity(JwtConstants.TokenType, TokenConstants.Claims.Name, TokenConstants.Claims.Role);
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Subject, email));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Name, name));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Email, email));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.UserId, userId.ToString()));
           

            if (isGlobalAdmin)
                claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, Data.Constants.Role.AdministratorName));

            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, Data.Constants.Role.MemberName));

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
