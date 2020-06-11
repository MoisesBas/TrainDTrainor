using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExam
{
    
    public class TrainingExamServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingExam, TrainingExamReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingExam, TrainingExamReadModel, TrainingExamCreateModel, TrainingExamUpdateModel>(services);          
        }
    }
}
