using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.JobHistory.Models;

namespace TrainDTrainorV2.Core.Domain.JobHistory
{
   public class JobHistoryServiceRegistration: DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.UserProfileJobHistory, JobHistoryReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.UserProfileJobHistory, JobHistoryReadModel, JobHistoryCreateModel, JobHistoryUpdateModel>(services);
        }
    }
}
