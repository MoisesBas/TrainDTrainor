using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.ExamResult.Commands;
using TrainDTrainorV2.Core.Domain.ExamResult.Handlers;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult
{
   
    public class ExamResultServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)

        {
            RegisterEntityQuery<Guid, Data.Entities.TraineeExamResult, ExamResultReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TraineeExamResult, ExamResultReadModel, ExamResultCreateModel, ExamResultUpdateModel>(services);
            services.TryAddTransient<IRequestHandler<ExamResultCommand<ExamResultCreateModel>, IEnumerable<ExamResultReadModel>>, ExamResultCommandHandler>();
            services.TryAddTransient<IRequestHandler<ExamResultCommand<IEnumerable<ExamResultUpdateModel>>, IEnumerable<ExamResultReadModel>>, ExamResultUpdateCommandHandler>();

        }
    }
}
