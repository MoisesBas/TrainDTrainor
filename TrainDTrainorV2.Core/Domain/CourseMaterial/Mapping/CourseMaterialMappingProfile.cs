using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Mapping
{
    public class CourseMaterialMappingProfile : AutoMapper.Profile
    {
        public CourseMaterialMappingProfile()
        {
            CreateMap<Data.Entities.CourseMaterial, CourseMaterialReadModel>()
                .ForMember(d => d.CourseName, opt => opt.MapFrom(s => s.Course.Title))               
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.CourseMaterialPic, CourseMaterialReadModel>()
              .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id))
              .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
              .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));
            CreateMap<CourseMaterialCreateModel, Data.Entities.CourseMaterial>()
                .ForMember(d => d.Name, opt => opt.MapFrom(d => d.Name));
            CreateMap<CreateResult, Data.Entities.CourseMaterial>()
                 .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));
        }
    }
}
