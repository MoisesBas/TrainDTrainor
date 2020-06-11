using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Education.Commands;
using TrainDTrainorV2.Core.Domain.Education.Handlers;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.Core.Domain.Education
{
    public class EducationServiceRegistration: DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.Education, EducationReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Education, EducationReadModel, EducationCreateModel, EducationUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<EducationReadCommand<Core.Data.Entities.Education>, EntityListResult<EducationReadModel>>, EducationReadCommandHandlers>();
        }
    }
}
