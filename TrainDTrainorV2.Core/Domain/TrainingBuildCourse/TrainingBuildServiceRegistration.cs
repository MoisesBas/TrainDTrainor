using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Handlres;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse
{
    public class TrainingBuildServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingBuildCourse, TrainingBuildCourseReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingBuildCourse, TrainingBuildCourseReadModel, TrainingBuildCourseCreatedModel, TrainingBuildCourseUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<TrainingBuildCourseDetailCommand, TrainingBuildCourseReadModel>, TrainingBuildCourseDetailCommandHandler>();            services.TryAddTransient<IRequestHandler<TrainingBuildCourseBulkInsertCommand<Data.Entities.TrainingBuildCourse, TrainingBuildCourseCreatedModel, TrainingBuildCourseReadModel>, IEnumerable<TrainingBuildCourseReadModel>>, TrainingBuildCourseBulkInsertCommandHandler>();
        }
    }
}
