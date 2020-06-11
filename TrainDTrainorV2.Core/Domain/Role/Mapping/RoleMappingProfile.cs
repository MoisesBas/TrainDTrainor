using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Role.Mapping
{
    public class CountryMappingProfile : AutoMapper.Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<RoleCreateModel, Data.Entities.Role>();
            CreateMap<RoleUpdateModel, Data.Entities.Role>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.Role, RoleReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));


        }
    }
}
