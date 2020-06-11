using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Validation
{
   public class TrainingBuildCoursesAttendeeCreatedModelValidator : AbstractValidator<TrainingBuildCoursesAttendeeCreatedModel>
    {
        public TrainingBuildCoursesAttendeeCreatedModelValidator()
        {
            RuleFor(p => p.CourseId).NotEmpty();
            RuleFor(p => p.AttendeeId).NotEmpty();            
        }
    }
}
