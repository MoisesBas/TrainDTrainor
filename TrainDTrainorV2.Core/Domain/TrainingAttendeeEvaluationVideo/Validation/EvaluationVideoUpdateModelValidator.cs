using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Validation
{
   public class EvaluationVideoUpdateModelValidator: AbstractValidator<EvaluationVideoUpdateModel>
    {
        public EvaluationVideoUpdateModelValidator()
        {
            RuleFor(p => p.TrainingBuildCourseAttendeeId).NotNull();
            RuleFor(p => p.CourseLevelId).NotNull();
            RuleFor(p => p.File).NotNull();
        }
    }
}
