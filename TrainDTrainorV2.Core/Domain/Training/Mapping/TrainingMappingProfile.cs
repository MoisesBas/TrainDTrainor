using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainDTrainorV2.Core.Domain.Training.Models;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.Training.Mapping
{
    public class TrainingMappingProfile:AutoMapper.Profile
    {
        public TrainingMappingProfile()
        {
            CreateMap<TrainingCreateModel, Data.Entities.Training>();
            CreateMap<TrainingUpdateModel, Data.Entities.Training>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(x => Convert.FromBase64String(x.RowVersion)));
            CreateMap<Data.Entities.TrainingVideo, TrainingVideoReadModel>()
                .ForMember(d => d.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(d => d.TrainingName, opt => opt.MapFrom(x => x.Training.Title))
                .ForMember(d => d.TrainingId, opt => opt.MapFrom(x => x.TrainingId))
                .ForMember(d=>d.FileId, opt=>opt.MapFrom(x=>x.FileId));
            
            CreateMap<Data.Entities.Training, TrainingDetailReadModel>()
                .ForMember(d => d.Steps, opt => opt.MapFrom(x=> this.GetLevelModels(x.Levels)))
                .ForMember(d => d.Videos, opt => opt.MapFrom(x => x.TrainingVideos))
                .ForMember(d => d.LatestVideo, opt => opt.MapFrom(x => x.TrainingVideos
                .OrderByDescending(g=>g.Id).FirstOrDefault())
                );

            CreateMap<Data.Entities.Training, TrainingReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
        private IEnumerable<LevelModel> GetLevelModels(IEnumerable<Data.Entities.Level> levels)
        {
            int counter = 0;
            foreach(var item in levels)
            {
                counter = counter + 1;
                yield return new LevelModel {
                   Step = counter,
                    LevelId = item.Id
                };
            }
        }
    }
}
