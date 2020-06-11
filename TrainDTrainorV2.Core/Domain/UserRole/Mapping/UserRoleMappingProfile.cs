using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.UserRole.Models;

namespace TrainDTrainorV2.Core.Domain.UserRole.Mapping
{
    public class UserRoleMappingProfile : AutoMapper.Profile
    {
        public UserRoleMappingProfile()
        {
            CreateMap<Data.Entities.User, Data.Entities.UserRole>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(d => d.Id));
            CreateMap<Data.Entities.Role, Data.Entities.UserRole>()
                .ForMember(d => d.RoleId, opt => opt.MapFrom(d => d.Id));
            CreateMap<Data.Entities.UserRole, UserRoleReadModel>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => s.RowVersion != null ? Convert.ToBase64String(s.RowVersion) : string.Empty));

            CreateMap<UserRoleReadModel, UserReadModel>()
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(d => d.User.EmailAddress))
                .ForMember(d => d.Id, opt => opt.MapFrom(d => d.User.Id))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(d => d.User.DisplayName))
                .ForMember(d => d.OTP, opt => opt.Ignore())
                .ForMember(d => d.IsEmailAddressConfirmed, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(x=>x.User.PhoneNumber))
                .ForMember(d => d.IsPhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(d => d.ResetHash, opt => opt.Ignore())
                .ForMember(d => d.InviteHash, opt => opt.Ignore())
                .ForMember(d => d.AccessFailedCount, opt => opt.Ignore())
                .ForMember(d => d.LockoutEnabled, opt => opt.Ignore())
                .ForMember(d => d.LockoutEnd, opt => opt.Ignore())
                .ForMember(d => d.LastLogin, opt => opt.Ignore())
                .ForMember(d => d.IsGlobalAdministrator, opt => opt.Ignore())
                .ForMember(d => d.IsAgree, opt => opt.Ignore())                
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));




        }
    }
}
