using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.LevelQuestion
{
    public class LevelQuestionServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.LevelQuestion, LevelQuestionReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.LevelQuestion, LevelQuestionReadModel, LevelQuestionCreateModel, LevelQuestionUpdateModel>(services);
        }
    }
}
