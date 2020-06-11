using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Role
{
    public class RoleServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)

        {
            RegisterEntityQuery<Guid, Data.Entities.Role, RoleReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Role, RoleReadModel, RoleCreateModel, RoleUpdateModel>(services);

            
        }
    }
}
