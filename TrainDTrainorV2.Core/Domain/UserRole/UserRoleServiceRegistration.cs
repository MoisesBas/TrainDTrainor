using System;
using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Domain.User.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain.UserRole.Models;

namespace TrainDTrainorV2.Core.Domain.UserRole
{
    public class UserRoleServiceRegistration : DomainServiceRegistrationBase
    {

        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.UserRole, UserRoleReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.UserRole, UserRoleReadModel, UserRoleCreateModel, UserRoleUpdateModel>(services);
        }
    }
}
