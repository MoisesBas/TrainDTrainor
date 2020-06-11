using MediatR;
using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.User.Commands
{
    public class UserCommand: IRequest<EntityListResult<UserReadModel>>
    {
        public UserCommand()
        {
        }      
    }
}
