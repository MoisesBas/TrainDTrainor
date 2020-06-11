using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;

namespace TrainDTrainorV2.Core.Domain.LevelSubject.Mapping
{
   public class LevelSubjectMappingProfile : AutoMapper.Profile
    {
        public LevelSubjectMappingProfile()
        {
            CreateMap<Data.Entities.LevelSubject, LevelSubjectReadModel>()
               .ForMember(d => d.LevelName, opt => opt.MapFrom(s => s.Level.Title))                
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));            
            CreateMap<LevelSubjectCreateModel, Data.Entities.LevelSubject>()
                .ForMember(d => d.Name, opt => opt.MapFrom(d => d.Name));
            CreateMap<LevelSubjectUpdateModel, Data.Entities.LevelSubject>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

        }
        
    }
}
