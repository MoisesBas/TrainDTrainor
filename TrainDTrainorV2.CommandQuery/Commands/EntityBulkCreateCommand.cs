using System;
using System.Collections.Generic;
using System.Security.Principal;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public class EntityBulkCreateCommand<TEntity, TCreateModel, TReadModel> : EntityBulkModelCommand<TCreateModel, IEnumerable<TReadModel>>
        where TEntity : class, new()
    {
        public EntityBulkCreateCommand(IEnumerable<TCreateModel> model, IPrincipal principal) : base(model, principal)
        {
            var identityName = principal?.Identity?.Name;
            if (model != null)
            {
                foreach (var m in model)
                {
                    if (m is ITrackCreated createdModel)
                    {
                        createdModel.Created = DateTimeOffset.UtcNow;
                        createdModel.CreatedBy = identityName;
                    }

                    if (m is ITrackUpdated updatedModel)
                    {
                        updatedModel.Updated = DateTimeOffset.UtcNow;
                        updatedModel.UpdatedBy = identityName;
                    }
                }
            }
        }
    }
}
