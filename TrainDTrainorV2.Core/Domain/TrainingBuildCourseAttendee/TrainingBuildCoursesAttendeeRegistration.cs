using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee
{
    public class TrainingBuildCoursesAttendeeRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingBuildCourseAttendee, TrainingBuildCoursesAttendeeReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingBuildCourseAttendee, TrainingBuildCoursesAttendeeReadModel, TrainingBuildCoursesAttendeeCreatedModel, TrainingBuildCoursesAttendeeUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<MapToCourseCommand<TrainingBuildCoursesAttendeeUpdateModel>, EntitySingleResult<TrainingBuildCoursesAttendeeReadModel>>, MapToCourseCommandHandler>();           

        }
    }
}
