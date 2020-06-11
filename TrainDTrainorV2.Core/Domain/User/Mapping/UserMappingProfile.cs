using System;
using System.Linq;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Models;

namespace TrainDTrainorV2.Core.Domain.Mapping
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserSendOTPModel, Data.Entities.User>();
            CreateMap<UserCreateModel, Data.Entities.User>();
            CreateMap<UserVerifyOTPModel, Data.Entities.User>();
            CreateMap<UserResetPasswordModel, Data.Entities.User>();
            CreateMap<UserForgotPasswordModel, Data.Entities.User>();
            CreateMap<UserRegisterModel, Data.Entities.User>();
            CreateMap<UserAddModel, Data.Entities.User>();
            CreateMap<Data.Entities.User, Data.Entities.UserProfile>()
                .ForMember(d => d.MobilePhone, opt => opt.MapFrom(d => d.PhoneNumber))
                .ForMember(d => d.FullName, opt => opt.MapFrom(d => d.DisplayName))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(d => d.EmailAddress))
                .ForMember(d => d.UserId, opt => opt.MapFrom(d => d.Id));
            CreateMap<UserUpdateModel, Data.Entities.User>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.User, UserReadModel>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(src=>src.UserRoles.FirstOrDefault()))
                 .ForMember(d => d.Gender, opt => opt.MapFrom(src => src.UserProfiles.Gender))
                .ForMember(d => d.Course, opt => opt.MapFrom(src=> src.UserProfiles.PaymentTransactions != null ? src.UserProfiles.PaymentTransactions.FirstOrDefault().Course.Title:string.Empty))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Data.Entities.PaymentTransaction, UserReadModel>()
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(d => d.UserProfile.User.EmailAddress))
                .ForMember(d => d.IsEmailAddressConfirmed, opt => opt.MapFrom(d => d.UserProfile.User.IsEmailAddressConfirmed))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(d => d.UserProfile.User.PhoneNumber))
                .ForMember(d => d.Id, opt => opt.MapFrom(d => d.UserProfile.User.Id))
                .ForMember(d => d.IsPhoneNumberConfirmed, opt => opt.MapFrom(d => d.UserProfile.User.IsPhoneNumberConfirmed))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(d => d.UserProfile.User.DisplayName))
                .ForMember(d => d.ResetHash, opt => opt.MapFrom(d => d.UserProfile.User.ResetHash))
                .ForMember(d => d.InviteHash, opt => opt.MapFrom(d => d.UserProfile.User.InviteHash))
                .ForMember(d => d.AccessFailedCount, opt => opt.MapFrom(d => d.UserProfile.User.AccessFailedCount))
                .ForMember(d => d.LockoutEnabled, opt => opt.MapFrom(d => d.UserProfile.User.LockoutEnabled))
                .ForMember(d => d.LockoutEnd, opt => opt.MapFrom(d => d.UserProfile.User.LockoutEnd))
                .ForMember(d => d.LastLogin, opt => opt.MapFrom(d => d.UserProfile.User.LastLogin))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Data.Entities.TrainingBuildCourseAttendee, UserReadModel>()
               .ForMember(d => d.EmailAddress, opt => opt.MapFrom(d => d.Attendee.EmailAddress))
               .ForMember(d => d.IsEmailAddressConfirmed, opt => opt.MapFrom(d => d.Attendee.IsEmailAddressConfirmed))
               .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(d => d.Attendee.PhoneNumber))
               .ForMember(d => d.Id, opt => opt.MapFrom(d => d.Attendee.Id))
               .ForMember(d => d.IsPhoneNumberConfirmed, opt => opt.MapFrom(d => d.Attendee.IsPhoneNumberConfirmed))
               .ForMember(d => d.DisplayName, opt => opt.MapFrom(d => d.Attendee.DisplayName))
               .ForMember(d => d.ResetHash, opt => opt.MapFrom(d => d.Attendee.ResetHash))
               .ForMember(d => d.InviteHash, opt => opt.MapFrom(d => d.Attendee.InviteHash))
               .ForMember(d => d.AccessFailedCount, opt => opt.MapFrom(d => d.Attendee.AccessFailedCount))
               .ForMember(d => d.LockoutEnabled, opt => opt.MapFrom(d => d.Attendee.LockoutEnabled))
               .ForMember(d => d.LockoutEnd, opt => opt.MapFrom(d => d.Attendee.LockoutEnd))
               .ForMember(d => d.LastLogin, opt => opt.MapFrom(d => d.Attendee.LastLogin))
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

        }
    }
}
