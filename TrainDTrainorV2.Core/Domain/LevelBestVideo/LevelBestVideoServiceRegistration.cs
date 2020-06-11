using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Handlers;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo
{
    public class LevelBestVideoServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.LevelVideo, LevelBestVideoReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.LevelVideo, LevelBestVideoReadModel, LevelBestVideoCreateModel, LevelBestVideoUpdateModel>(services);
            RegisterEntityQuery<Guid, Data.Entities.LevelVideoPic, LevelBestVideoReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.LevelVideoPic, LevelBestVideoReadModel, object, object>(services);
            services.TryAddTransient<IRequestHandler<LevelBestVideoCommand<LevelBestVideoCreateModel>, LevelBestVideoReadModel>, LevelBestVideoCommandHandler>(); services.AddTransient<IPipelineBehavior<LevelBestVideoCommand<LevelBestVideoCreateModel>, LevelBestVideoReadModel>, ValidateEntityModelCommandBehavior<LevelBestVideoCreateModel, LevelBestVideoReadModel>>();
            services.TryAddTransient<IRequestHandler<LevelBestVideoGetCommand<Guid>, LevelBestVideoReadModel>, LevelBestVideoGetCommandHandler>();
        }
    }
}
