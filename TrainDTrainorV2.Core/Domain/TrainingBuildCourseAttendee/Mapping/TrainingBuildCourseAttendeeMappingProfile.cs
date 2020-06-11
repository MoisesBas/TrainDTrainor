using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Mapping
{
    public class TrainingBuildCourseAttendeeMappingProfile : AutoMapper.Profile
    {
        public TrainingBuildCourseAttendeeMappingProfile()
        {
            CreateMap<TrainingBuildCoursesAttendeeCreatedModel, Data.Entities.TrainingBuildCourseAttendee>()
                .ForMember(d=>d.IsActive, opt => opt.MapFrom(src => true));
            CreateMap<TrainingBuildCoursesAttendeeUpdateModel, Data.Entities.TrainingBuildCourseAttendee>()
                 .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
            CreateMap<Data.Entities.TrainingBuildCourseAttendee, TrainingBuildCoursesAttendeeReadModel>()
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(x=>x.Attendee.DisplayName))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(x=>x.IsActive))
                .ForMember(d => d.Course, opt => opt.MapFrom(x=>x.Course.Title))
                .ForMember(d => d.Courses, opt => opt.MapFrom(x=>x.Course))
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            CreateMap<TrainingBuildCoursesAttendeeUpdateModel, TrainingBuildCoursesAttendeeCreatedModel>()
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<TrainingBuildCoursesAttendeeReadModel, TrainingBuildCoursesAttendeeUpdateModel>()
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => false));
            CreateMap<PaymentReadModel, PaymentHistoryCreateModel>()

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
