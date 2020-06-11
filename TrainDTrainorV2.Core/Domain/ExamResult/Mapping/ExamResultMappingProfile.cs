using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Mapping
{
    public class ExamResultMappingProfile : AutoMapper.Profile
    {
        public ExamResultMappingProfile()
        {
            CreateMap<ExamResultCreateModel, Data.Entities.TraineeExamResult>();
            CreateMap<ExamResultUpdateModel, Data.Entities.TraineeExamResult>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<ExamResultUpdateModel, Data.Entities.TraineeExamResult>()
              .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion))).ReverseMap();
            CreateMap<TrainingExamReadModel, ExamResultCreateModel>()
                .ForMember(d => d.QuestionId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.IsCorrect, opt => opt.MapFrom( s => false))
                .ForMember(d => d.Answer, opt => opt.MapFrom(s => string.Empty));
            CreateMap<Data.Entities.TraineeExamResult, ExamResultReadModel>()
                .ForMember(d => d.Question, opt => opt.MapFrom(s=>s.Question))
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
