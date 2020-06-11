using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Achievement.Model;

namespace TrainDTrainorV2.Core.Domain.Achievement
{
    public class AchievementServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.UserProfileAchievements, AchievementReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.UserProfileAchievements, AchievementReadModel, AchievementCreateModel, AchievementUpdateModel>(services);
        }
    }
}
