using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Mapping
{
    public class TrainingExperienceMappingProfile: AutoMapper.Profile
    {
        public TrainingExperienceMappingProfile()
        {
            CreateMap<TrainingExperienceCreatedModel, Data.Entities.TrainingExperience>();
            CreateMap<TrainingExperienceUpdatedModel, Data.Entities.TrainingExperience>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingExperience, TrainingExperienceReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
