using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Security;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserChangePasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserChangePasswordModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserChangePasswordCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserChangePasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;
            var userId = message.Principal.Identity.GetUserId();
            var emailAddress = message.Principal.Identity.GetUserName();

            // check for existing user
            var user = await _dataContext.Users
                .FindAsync(userId)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{emailAddress}' not found.");

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, model.CurrentPassword))
                throw new DomainException(HttpStatusCode.Unauthorized, "The password is incorrect");

            var passwordHashed = _passwordHasher
                .HashPassword(model.UpdatedPassword);

            user.PasswordHash = passwordHashed;
            user.UpdatedBy = emailAddress;
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}
