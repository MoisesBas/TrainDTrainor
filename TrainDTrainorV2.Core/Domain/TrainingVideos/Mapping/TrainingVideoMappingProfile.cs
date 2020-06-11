using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Mapping
{
    public class TrainingVideoMappingProfile: AutoMapper.Profile
    {
        public TrainingVideoMappingProfile()
        {
            CreateMap<Data.Entities.TrainingVideo, TrainingVideoReadModel>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.TrainingName, opt => opt.MapFrom(s=>s.Training.Title))
                .ForMember(d => d.TrainingId, opt => opt.MapFrom(s => s.Training.Id))
                .ForMember(d=>d.Path, opt => opt.Ignore())
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.CreateResult, Data.Entities.TrainingVideo>()
             .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));

            CreateMap<Data.Entities.TrainingVideoPic, TrainingVideoReadModel>()
                .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id))
                .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));

            CreateMap<TrainingVideoCreateModel, Data.Entities.TrainingVideo>();
            CreateMap<TrainingVideoUpdateModel, Data.Entities.TrainingVideo>() 
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingVideo, TrainingVideoReadModel>()
                .ForMember(d => d.FileId, opt=>opt.MapFrom(s=>s.FileId))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
