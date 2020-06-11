using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Country.Models;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Country
{
    public class CountryServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.Country, CountryReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Country, CountryReadModel, CountryCreateModel, CountryUpdateModel>(services);

            
        }
    }
}
