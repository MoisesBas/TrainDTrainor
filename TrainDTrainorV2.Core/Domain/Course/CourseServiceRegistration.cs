using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Commands;
using TrainDTrainorV2.Core.Domain.Course.Handlers;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course
{
    public class CourseServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)

        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingCourse, CourseReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingCourse, CourseReadModel, CourseCreateModel, CourseUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<CourseDetailReadCommand, CourseReadModel>, CourseDetailReadCommandHandler>();
        }
    }
}
