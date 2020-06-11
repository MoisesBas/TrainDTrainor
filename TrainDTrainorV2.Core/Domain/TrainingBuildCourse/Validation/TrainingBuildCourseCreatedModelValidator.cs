using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Validation
{
   public  class TrainingBuildCourseCreatedModelValidator: AbstractValidator<TrainingBuildCourseCreatedModel>
    {
        public TrainingBuildCourseCreatedModelValidator()
        {
            RuleFor(p => p.CourseId).NotEmpty();
            RuleFor(p => p.LevelId).NotEmpty();
            RuleFor(p => p.QuestionId).NotEmpty();
        }
    }
}
