using System;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Definitions;
using TrainDTrainorV2.CommandQuery.Helper;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public class EntityCreateCommand<TEntity, TCreateModel, TReadModel> : EntityModelCommand<TCreateModel, TReadModel>
        where TEntity : class, new()
    {
        public EntityCreateCommand(TCreateModel model,
            IPrincipal principal) : base(model, principal)
        {

            var identityName = principal?.Identity?.Name;

            if (model is ITrackCreated createdModel)
            {
                createdModel.Created = DateTimeOffset.UtcNow;
                createdModel.CreatedBy = identityName;
            }

            if (model is ITrackUpdated updatedModel)
            {
                updatedModel.Updated = DateTimeOffset.UtcNow;
                updatedModel.UpdatedBy = identityName;
            }
        }

        
    }
}
