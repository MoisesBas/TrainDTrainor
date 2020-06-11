using System;
using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain.UserProfile.Commands;
using TrainDTrainorV2.Core.Domain.UserProfile.Handlers;

namespace TrainDTrainorV2.Core.Domain.UserProfile
{
   public  class UserProfileServiceRegistration: DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.UserProfile, UserProfileReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.UserProfile, UserProfileReadModel, UserProfileCreateModel, UserProfileUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<UserProfileCommand, UserProfileReadModel>, UserProfileCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserProfileGetCommand, UserProfileReadModel>, UserProfileGetCommandHandler>();
        }
    }
}
