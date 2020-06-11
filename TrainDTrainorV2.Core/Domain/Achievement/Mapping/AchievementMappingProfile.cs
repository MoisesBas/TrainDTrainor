using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Achievement.Model;

namespace TrainDTrainorV2.Core.Domain.Achievement.Mapping
{
   public class AchievementMappingProfile: AutoMapper.Profile
    {
        public AchievementMappingProfile()
        {
            CreateMap<AchievementCreateModel, Data.Entities.UserProfileAchievements>();
            CreateMap<AchievementUpdateModel, Data.Entities.UserProfileAchievements>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.UserProfileAchievements, AchievementReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
