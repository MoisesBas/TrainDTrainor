using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Mapping
{
    public class UserProfileMappingProfile : AutoMapper.Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<Data.Entities.UserProfilePic, Data.CreateResult>()
                .ForMember(d => d.Path, opt => opt.MapFrom(d => d.Path))
                .ForMember(d => d.Stream_id, opt => opt.MapFrom(d => d.Stream_id));
            CreateMap<UserProfileCreateModel, Data.Entities.UserProfile>();
            CreateMap<Data.CreateResult, Data.Entities.UserProfile>()
                .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));
            CreateMap<Data.Entities.UserProfilePic, Data.CreateResult>()
             .ForMember(d => d.Stream_id, opt => opt.MapFrom(d => d.Stream_id))
             .ForMember(d => d.Path, opt => opt.MapFrom(d => d.Path));
            CreateMap<Data.Entities.UserProfile, UserProfileReadModel>();
            CreateMap<Data.Entities.UserProfilePic, UserProfileReadModel>()
                .ForMember(d => d.ProfilePicId, opt => opt.MapFrom(d => d.Stream_id))
                .ForMember(d => d.ProfilePicPath, opt => opt.MapFrom(src => src.Path + src.Name))
                .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
                .ForMember(d =>d.ProfilePicPath, opt => opt.MapFrom(src => src.fullpath));
            CreateMap<UserProfileUpdateModel, Data.Entities.UserProfile>()               
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.UserProfile, UserProfileReadModel>()               
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.UserProfile,Data.Entities.User>()
                .ForMember(d=>d.DisplayName, opt => opt.MapFrom(src=>src.FullName))
                .ForMember(d=>d.EmailAddress, opt => opt.MapFrom(src=>src.EmailAddress))
                .ForMember(d=>d.PhoneNumber, opt => opt.MapFrom(src=>src.MobilePhone));
        }
    }
}
