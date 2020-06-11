using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Mapping
{
    public class ExamResultMappingProfile : AutoMapper.Profile
    {
        public ExamResultMappingProfile()
        {
            CreateMap<TrainingExamCreateModel, Data.Entities.TrainingExam>();
            CreateMap<TrainingExamUpdateModel, Data.Entities.TrainingExam>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingExam, TrainingExamReadModel>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
