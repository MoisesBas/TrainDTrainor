using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Mapping
{
    public class CourseMappingProfile : AutoMapper.Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseCreateModel, Data.Entities.TrainingCourse>();
            CreateMap<CourseUpdateModel, Data.Entities.TrainingCourse>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingCourse, CourseReadModel>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
