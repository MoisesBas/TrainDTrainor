using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Commands
{

    public class CourseMaterialCommand<TCreateModel> : EntityCreateCommand<Data.Entities.CourseMaterial, TCreateModel, CourseMaterialReadModel>
    {
        public CourseMaterialCommand(TCreateModel model, UserAgentModel userAgent) : base(model, null)
        {
            Model = model;
            UserAgentModel = userAgent;
        }
        public UserAgentModel UserAgentModel { get; set; }
    }
}
