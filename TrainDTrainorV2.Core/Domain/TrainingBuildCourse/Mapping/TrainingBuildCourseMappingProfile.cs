﻿using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Mapping
{
    public class TrainingBuildCourseMappingProfile: AutoMapper.Profile
    {
        public TrainingBuildCourseMappingProfile()
        {
            CreateMap<TrainingBuildCourseCreatedModel, Data.Entities.TrainingBuildCourse>();
            CreateMap<TrainingBuildCourseUpdateModel, Data.Entities.TrainingBuildCourse>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingBuildCourse, TrainingBuildCourseReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
