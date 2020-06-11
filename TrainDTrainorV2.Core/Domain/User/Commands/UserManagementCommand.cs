using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.User.Commands
{
    public class UserManagementCommand<TUserModel> : EntityModelCommand<TUserModel, UserReadModel>
    {
        public UserManagementCommand(TUserModel model) : base(model, null)
        {
        }

        public UserManagementCommand(TUserModel model, IPrincipal principal) : base(model, principal)
        {
        }

        public UserManagementCommand(TUserModel model, IPrincipal principal, UserAgentModel userAgent) : base(model, principal)
        {
            UserAgent = userAgent;
        }

        public UserAgentModel UserAgent { get; set; }
    }
}
