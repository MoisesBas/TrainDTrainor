using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo
{
    public class TrainingAttendeeEvaluationVideoServiceRegistration: DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {

            RegisterEntityQuery<Guid, Data.Entities.TraineeEvaluationVideo, EvaluationVideoReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TraineeEvaluationVideo, EvaluationVideoReadModel, EvaluationVideoCreateModel, EvaluationVideoUpdateModel>(services);
            RegisterEntityQuery<Guid, Data.Entities.TraineeEvaluationVideo, EvaluationVideoReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TraineeEvaluationVideo, EvaluationVideoReadModel, object, object>(services);
            services.TryAddTransient<IRequestHandler<EvaluationVideoCommand<EvaluationVideoCreateModel>, EvaluationVideoReadModel>, EvaluationVideoCommandHandler>(); services.AddTransient<IPipelineBehavior<EvaluationVideoCommand<EvaluationVideoCreateModel>, EvaluationVideoReadModel>, ValidateEntityModelCommandBehavior<EvaluationVideoCreateModel, EvaluationVideoReadModel>>();
            services.TryAddTransient<IRequestHandler<EvaluationVideoGetCommand<Guid>, EvaluationVideoReadModel>, EvaluationVideoGetCommandHandler>();
        }
    }
}
