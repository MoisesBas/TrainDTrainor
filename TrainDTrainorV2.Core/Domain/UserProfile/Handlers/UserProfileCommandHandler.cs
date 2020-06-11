using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.UserProfile.Commands;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Handlers
{
    public class UserProfileCommandHandler : RequestHandlerBase<UserProfileCommand, UserProfileReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public UserProfileCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<UserProfileReadModel> ProcessAsync(UserProfileCommand message, CancellationToken cancellationToken)
        {
            byte[] bytes;
            if (message.UserProfile == null) throw new DomainException(422, $"Unable to Register: User Profile is null , Please try again.");

            var currentUser = await _dataContext.UserProfiles
                                      .ByUserId(message.UserProfile.UserId)
                                      .ConfigureAwait(false);
            if(currentUser == null)
                throw new DomainException(422, $"User profile not found, Please try again.");
            _mapper.Map(message.UserProfile, currentUser);
            var user = _dataContext.Users.Where(x => x.Id == message.UserProfile.UserId).FirstOrDefault();

            if(user == null)
                throw new DomainException(422, $"User not found, Please try again.");
            _mapper.Map(currentUser, user);

            CreateResult result = new CreateResult();           
            result = _mapper.Map<CreateResult>(_dataContext.FindFolder(new UserProfilePic() { Name = typeof(UserProfilePic).Name }));
            if (result == null)
            {
                result = _dataContext.CreateDir(new UserProfilePic() { Name = typeof(UserProfilePic).Name, ParentPath = null });
            }
                if (message.UserProfile.File != null)
            {
                var file = message.UserProfile.File;
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var now = DateTimeOffset.Now;
                    var userProfilePic = new UserProfilePic()
                    {     
                        Stream_id = currentUser.FileId ?? Guid.NewGuid(),
                        Name = Guid.NewGuid() + "_" + message.UserProfile.File.FileName,
                        File_stream = ms.ToArray(),
                        ParentPath = result.Path,
                        Creation_time = now,
                        Last_access_time = now,
                        Last_write_time = now
                    };
                    result = currentUser.FileId.HasValue ? _dataContext.UpdateFile(userProfilePic) : _dataContext.CreateFile(userProfilePic);
                }           
               _mapper.Map(result, currentUser);
            }
            if (result != null)
            {
                var status = await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (status != 0)
                {
                    return _mapper.Map<UserProfileReadModel>(currentUser);
                }
                else
                {
                    Logger.LogWarning($"Unable to update user profile '{currentUser.FullName }' please try again later or contact administrator.");
                    throw new DomainException(422, $"Unable to update user profile '{currentUser.FullName }' please try again later or contact administrator.");
                }
            }
            else
            {
                Logger.LogWarning($"Unable to update user profile '{currentUser.FullName }' please try again later or contact administrator.");
                throw new DomainException(422, $"Unable to update user profile '{currentUser.FullName }' please try again later or contact administrator.");
            }
        }
       
    }
}
