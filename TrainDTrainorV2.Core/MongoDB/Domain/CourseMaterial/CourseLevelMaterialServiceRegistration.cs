using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Handlers;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial
{
    
    public class CourseLevelMaterialServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<CourseMaterialCommand, ReadCourseMaterial>, CourseMaterialCommandHandler>();
        }
    }
}
