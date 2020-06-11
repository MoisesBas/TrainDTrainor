using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.Core.Domain.Education.Mapping
{
   public class EducationMappingProfile: AutoMapper.Profile
    {
        public EducationMappingProfile()
        {
            CreateMap<EducationCreateModel, Data.Entities.Education>();
            CreateMap<EducationUpdateModel, Data.Entities.Education>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.Education, EducationReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
