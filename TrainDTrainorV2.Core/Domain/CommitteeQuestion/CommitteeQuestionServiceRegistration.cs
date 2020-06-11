using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.CommitteeQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.CommitteeQuestion
{
   
    public class CommitteeQuestionServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.CommitteeQuestion, CommitteeQuestionReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.CommitteeQuestion, CommitteeQuestionReadModel, CommitteeQuestionCreateModel, CommitteeQuestionUpdateModel>(services);
        }
    }
}
