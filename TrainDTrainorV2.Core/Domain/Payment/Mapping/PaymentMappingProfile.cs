using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.Payment.Mapping
{
    public class PaymentMappingProfile : AutoMapper.Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<PaymentCreateModel, Data.Entities.PaymentTransaction>();
            CreateMap<Data.Entities.PaymentDetailApproval, PaymentDetailApprovalModel>();
            CreateMap<Data.CreateResult, Data.Entities.PaymentTransaction>()
               .ForMember(d => d.FileId, opt => opt.MapFrom(d => d.Stream_id));
            CreateMap<Data.Entities.PaymentTransactionPic, PaymentReadModel>()
                .ForMember(d => d.PaymentPicId, opt => opt.MapFrom(d => d.Stream_id))
                .ForMember(d => d.PaymentPicPath, opt => opt.MapFrom(src => src.Path + src.Name))
                .ForMember(d => d.FileName, opt => opt.MapFrom(src => src.Name.SplitName()))
                .ForMember(d => d.PaymentPicPath, opt => opt.MapFrom(src => src.fullpath));
            CreateMap<PaymentReadModel, PaymentUpdateModel>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<PaymentUpdateModel, Data.Entities.PaymentTransaction>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.PaymentTransaction, PaymentReadModel>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<Data.Entities.PaymentTransaction, PaymentDetailApprovalModel>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(d => d.CourseId, opt => opt.MapFrom(src => src.CourseId))
                 .ForMember(d => d.Course, opt => opt.MapFrom(src => src.Course.Title))
                 .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                  .ForMember(d => d.PaymentPicId, opt => opt.MapFrom(src => src.FileId))
                 .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Status))
                 .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.UserProfile.FullName))
                 .ForMember(d => d.Country, opt => opt.MapFrom(src => src.UserProfile.Country))
                 .ForMember(d => d.City, opt => opt.MapFrom(src => src.UserProfile.City))
                 .ForMember(d => d.Age, opt => opt.MapFrom(src => src.UserProfile.Age))
                 .ForMember(d => d.Nationality, opt => opt.MapFrom(src => src.UserProfile.Nationality))
                 .ForMember(d => d.JobTitle, opt => opt.MapFrom(src => src.UserProfile.JobTitle))
                 .ForMember(d => d.EmailAddress, opt => opt.MapFrom(src => src.UserProfile.EmailAddress))
                 .ForMember(d => d.MobilePhone, opt => opt.MapFrom(src => src.UserProfile.MobilePhone))
                 .ForMember(d => d.BusinessPhone, opt => opt.MapFrom(src => src.UserProfile.BusinessPhone))
                 .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserProfile.UserId))
                 .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                 .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created))
                 .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                 .ForMember(d => d.Updated, opt => opt.MapFrom(src => src.Updated))
                 .ForMember(d => d.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))                
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<CourseReadModel,CourseUpdateModel>()
               .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<PaymentReadModel, TrainingBuildCoursesAttendeeCreatedModel>()
                .ForMember(d => d.AttendeeId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.CourseId, opt => opt.MapFrom(src => src.CourseId));

            CreateMap<PaymentReadModel, Data.Entities.PaymentTransactionHistory>()
                .ForMember(d =>d.Id, opt => opt.Ignore())
                 .ForMember(d => d.PaymentTransactionId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))     
                 .ForMember(d => d.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                 .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                 .ForMember(d => d.FileId, opt => opt.MapFrom(src => src.PaymentPicId))
                 .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Status))
                 .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                 .ForMember(d => d.CourseId, opt => opt.MapFrom(src => src.CourseId));


        }
    }
}
