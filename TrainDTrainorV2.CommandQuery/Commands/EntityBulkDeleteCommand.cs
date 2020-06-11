using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.CommandQuery.Commands
{
    public class EntityBulkDeleteCommand<TEntity, TUpdateModel, TReadModel> : EntityBulkModelCommand<TUpdateModel, IEnumerable<TReadModel>>
        where TEntity : class, new()
    {
        public EntityBulkDeleteCommand(IEnumerable<TUpdateModel> model, IPrincipal principal) : base(model, principal)
        {
            var identityName = principal?.Identity?.Name;
            if (model != null)
            {
                foreach (var m in model)
                {
                    if (m is ITrackUpdated updatedModel)
                    {

                        updatedModel.Updated = DateTimeOffset.UtcNow;
                        updatedModel.UpdatedBy = identityName;
                    }
                    if (m is ITrackDeleted deleteModel)
                    {
                        deleteModel.IsDeleted = true;
                    }
                }
            }
        }
    }
}
