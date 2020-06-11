using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.CommitteeQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.CommitteeQuestion.Mapping
{
   
    public class CommitteeQuestionMappingProfile : AutoMapper.Profile
    {
        public CommitteeQuestionMappingProfile()
        {
            CreateMap<CommitteeQuestionCreateModel, Data.Entities.CommitteeQuestion>();
            CreateMap<CommitteeQuestionUpdateModel, Data.Entities.CommitteeQuestion>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.CommitteeQuestion, CommitteeQuestionReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
