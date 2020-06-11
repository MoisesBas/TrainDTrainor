using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.User.Commands
{   
    public class UserPaidCommand<TUser> : IRequest<EntityListResult<UserReadModel>>
    {
        public UserPaidCommand(EntityQuery<TUser> entityQuery, 
            Guid courseId)
        {
            EntityQuery = entityQuery;           
            CourseId = courseId;
        }
      
        public Guid CourseId { get; set; }
        public EntityQuery<TUser> EntityQuery { get; set; }
    }
}
