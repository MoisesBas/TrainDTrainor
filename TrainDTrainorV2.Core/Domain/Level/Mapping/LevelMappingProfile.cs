using System;
using System.Collections.Generic;
using System.Linq;
using TrainDTrainorV2.Core.Domain.Level.Models;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.Level.Mapping
{
    public class LevelMappingProfile : AutoMapper.Profile
    {
        public LevelMappingProfile()
        {
            CreateMap<LevelCreateModel,
                Data.Entities.Level>();
            CreateMap<LevelUpdateModel, Data.Entities.Level>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.LevelVideo, LevelBestVideoReadModel>()
                .ForMember(d => d.LevelName, opt => opt.MapFrom(s => s.Level.Title))
                .ForMember(d => d.Path, opt => opt.Ignore())
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.LevelVideoPic, LevelBestVideoReadModel>()
              .ForMember(d => d.BestVideoId, opt => opt.MapFrom(d => d.Stream_id))
              .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
              .ForMember(d => d.Path, opt => opt.MapFrom(src => src.fullpath));
           
            CreateMap<Data.Entities.LevelSubject, LevelSubjectReadModel>()
                 .ForMember(d => d.LevelId, opt => opt.MapFrom(src=>src.LevelId))
                 .ForMember(d => d.LevelName, opt => opt.MapFrom(src => src.Level.Title))
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.Level, LevelReadModel>()
                .ForMember(d =>d.Questions, opt => opt.MapFrom(s=>s.LevelQuestions.Where(x=> x.QuestionType ==  (int)QuestionType.Question)))
                .ForMember(d => d.Improvements, opt => opt.MapFrom(s => s.LevelQuestions.Where(x => x.QuestionType == (int)QuestionType.Improvements)))
                .ForMember(d =>d.Strengths,opt => opt.MapFrom(s => s.LevelQuestions.Where(x => x.QuestionType == (int)QuestionType.Strength)))
                .ForMember(d =>d.Videos, opt => opt.MapFrom(x=>x.LevelVideos))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingBuildCourse, LevelSubjectReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingBuildCourse, LevelQuestionReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));       
            CreateMap<Data.Entities.TrainingBuildCourse, LevelReadModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Level.Description))
                .ForMember(d => d.TrainingId, opt => opt.MapFrom(src => src.Level.TrainingId))
                .ForMember(d => d.Subjects, opt => opt.MapFrom(src => src.Level.Subjects))
                .ForMember(d => d.Videos, opt => opt.Ignore())
                .ForMember(d => d.Questions, opt => opt.MapFrom(src => src.Level.LevelQuestions.Where(x => x.Id == src.QuestionId)))
                .ForMember(d => d.Strengths, opt => opt.MapFrom(src => src.Level.LevelQuestions.Where(x => x.Id == src.QuestionId)))
                .ForMember(d => d.Improvements, opt => opt.MapFrom(src => src.Level.LevelQuestions.Where(x => x.Id == src.QuestionId)))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}
