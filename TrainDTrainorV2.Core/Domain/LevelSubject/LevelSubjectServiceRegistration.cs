using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;

namespace TrainDTrainorV2.Core.Domain.LevelSubject
{
    public class LevelSubjectServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.LevelSubject, LevelSubjectReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.LevelSubject, LevelSubjectReadModel, LevelSubjectCreateModel, LevelSubjectUpdateModel>(services);
        }
    }
}
