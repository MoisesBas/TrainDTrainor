using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Security;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserResetPasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserResetPasswordModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserResetPasswordCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserResetPasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{model.EmailAddress}' not found.");

            if (!_passwordHasher.VerifyPassword(user.ResetHash, model.ResetToken))
                throw new DomainException(HttpStatusCode.Forbidden, "Invalid reset password security token.");


            var passwordHashed = _passwordHasher
                .HashPassword(model.UpdatedPassword);

            user.PasswordHash = passwordHashed;
            user.AccessFailedCount = 0;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}
