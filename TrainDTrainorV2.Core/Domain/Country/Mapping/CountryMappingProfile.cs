using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Country.Models;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Country.Mapping
{
    public class CountryMappingProfile : AutoMapper.Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryCreateModel, Data.Entities.Country>();
            CreateMap<CountryUpdateModel, Data.Entities.Country>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.Country, CountryReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));


        }
    }
}
