using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Mapping
{
    public class PaymentHisotryMappingProfile : AutoMapper.Profile
    {
        public PaymentHisotryMappingProfile()
        {
            CreateMap<PaymentHistoryCreateModel, Data.Entities.PaymentTransaction>();
            CreateMap<PaymentHistoryCreateModel, Data.Entities.PaymentTransactionHistory>()
                .ForMember(d => d.Id, opt =>opt.Ignore())                
                .ForMember(d => d.RowVersion, opt => opt.Ignore());
            CreateMap<PaymentHistoryUpdateModel, Data.Entities.PaymentTransaction>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.PaymentTransaction, Data.Entities.PaymentTransactionHistory>()
                 .ForMember(d => d.PaymentTransactionId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                 .ForMember(d => d.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                 .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                 .ForMember(d => d.FileId, opt => opt.MapFrom(src => src.FileId))
                 .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Status))
                 .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                 .ForMember(d => d.CourseId, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<PaymentHistoryReadModel, TrainingBuildCoursesAttendeeCreatedModel>()
                .ForMember(d => d.AttendeeId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.CourseId, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<Data.Entities.PaymentTransactionHistory, PaymentHistoryReadModel>()
                .ForMember(d => d.CourseId, opt => opt.MapFrom(src=>src.CourseId))
                 .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                 .ForMember(d => d.PaymentPicId, opt => opt.MapFrom(src => src.FileId))
                 .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                 .ForMember(d => d.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
                 .ForMember(d => d.PaymentPicPath, opt => opt.Ignore())
                 .ForMember(d => d.FileName, opt => opt.Ignore())
                 .ForMember(d => d.Status, opt => opt.Ignore())
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));




        }
    }
}
