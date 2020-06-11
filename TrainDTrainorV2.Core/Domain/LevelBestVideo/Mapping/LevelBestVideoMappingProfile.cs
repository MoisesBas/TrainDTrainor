using System;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Mapping
{
    public class LevelBestVideoMappingProfile: AutoMapper.Profile
    {
        public LevelBestVideoMappingProfile()
        {
            //map levelvideo 
            CreateMap<Data.Entities.LevelVideo, LevelBestVideoReadModel>()
                .ForMember(d => d.LevelName, opt => opt.MapFrom(s=>s.Level.Title))
                .ForMember(d => d.Path, opt => opt.Ignore())
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.LevelVideoPic, LevelBestVideoReadModel>()
              .ForMember(d => d.BestVideoId, opt => opt.MapFrom(d => d.Stream_id))
              .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
              .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));      
            CreateMap<LevelBestVideoCreateModel, Data.Entities.LevelVideo>()
                .ForMember(d=>d.Name, opt => opt.MapFrom(d=>d.VideoName));
            CreateMap<CreateResult,Data.Entities.LevelVideo>()
                 .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));
            //CreateMap<Data.Entities.LevelVideoPic, LevelBestVideoReadModel>()
            //    .ForMember(d => d.BestVideoId, opt => opt.MapFrom(d => d.Stream_id))
            //    .ForMember(d => d.Path, opt => opt.MapFrom(src => src.Path + src.Name))
            //    .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
            //    .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));
            //CreateMap<LevelBestVideoReadModel, LevelBestVideoUpdateModel>()
            //     .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            //CreateMap<LevelBestVideoUpdateModel, Data.Entities.LevelVideo>()
            //    .ForMember(d=>d.Name, opt => opt.MapFrom(src=> src.VideoName))
            //    .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            //CreateMap<Data.Entities.LevelVideo, LevelBestVideoReadModel>()
            //     .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
           

        }
    }
}
