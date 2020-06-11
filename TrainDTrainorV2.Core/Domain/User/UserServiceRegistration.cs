using System;
using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Domain.User.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.User.Models;

namespace TrainDTrainorV2.Core.Domain.User
{
    public class UserServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.User, UserReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.User, UserReadModel, UserCreateModel, UserUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserRegisterModel>, UserReadModel>, UserRegisterCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, UserChangePasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, UserForgotPasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, UserResetPasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserSendOTPModel>, UserReadModel>, UserSendOTPCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserVerifyOTPModel>, UserReadModel>, UserVerifyOTPCommandHandler>();

            services.TryAddTransient<IRequestHandler<UserPaidCommand<Data.Entities.User>, EntityListResult<UserReadModel>>, UserPaidCommandHandler>();

            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserAddModel>, UserReadModel>, AddUserCommandHandler>();

            services.TryAddTransient<IRequestHandler<UserCommand, EntityListResult<UserReadModel>>, UserCommandHandler>();

            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserAddModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserAddModel, UserReadModel>>();

            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserVerifyOTPModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserVerifyOTPModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserSendOTPModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserSendOTPModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserRegisterModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserRegisterModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserChangePasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserForgotPasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserResetPasswordModel, UserReadModel>>();
        }
    }
}
