using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.JobHistory.Models;

namespace TrainDTrainorV2.Core.Domain.JobHistory.Mapping
{
  public  class JobHistoryMappingProfile: AutoMapper.Profile
    {
        public JobHistoryMappingProfile()
        {
            CreateMap<JobHistoryCreateModel, Data.Entities.UserProfileJobHistory>();                
            CreateMap<JobHistoryUpdateModel, Data.Entities.UserProfileJobHistory>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.UserProfileJobHistory, JobHistoryReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
