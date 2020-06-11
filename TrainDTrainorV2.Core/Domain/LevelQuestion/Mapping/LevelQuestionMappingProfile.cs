using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.LevelQuestion.Mapping
{
    public class LevelQuestionMappingProfile : AutoMapper.Profile
    {
        public LevelQuestionMappingProfile()
        {
            CreateMap<LevelQuestionCreateModel, Data.Entities.LevelQuestion>();
            CreateMap<LevelQuestionUpdateModel, Data.Entities.LevelQuestion>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.LevelQuestion, LevelQuestionReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
