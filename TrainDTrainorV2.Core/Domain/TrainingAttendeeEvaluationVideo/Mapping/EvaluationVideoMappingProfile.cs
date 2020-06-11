using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Mapping
{
    class EvaluationVideoMappingProfile: AutoMapper.Profile
    {
        public EvaluationVideoMappingProfile()
        {
            CreateMap < Data.Entities.TraineeEvaluationVideo, EvaluationVideoReadModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Path, opt => opt.Ignore())
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.LevelVideoPic, EvaluationVideoReadModel>()
              .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id))
              .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
              .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));
            CreateMap<EvaluationVideoCreateModel, Data.Entities.TraineeEvaluationVideo>()
                .ForMember(d => d.Name, opt => opt.MapFrom(d => d.Name));
            CreateMap<Data.CreateResult, Data.Entities.LevelVideo>()
                 .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));
        }
    }
}
