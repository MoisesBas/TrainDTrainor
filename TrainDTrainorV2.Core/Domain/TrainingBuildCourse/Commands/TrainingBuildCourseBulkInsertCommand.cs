using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands
{
    public class TrainingBuildCourseBulkInsertCommand<TEntity,TCreateModel, TReadModel>: EntityBulkModelCommand<TCreateModel,IEnumerable<TReadModel>>
    {
        public TrainingBuildCourseBulkInsertCommand(IEnumerable<TCreateModel> model, IPrincipal principal) : base(model, principal)
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
