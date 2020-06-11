using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class TraineeEvaluationVideoPic : CreateFiletable
    {
        protected override string TableName => typeof(EvaluationVideoPic).Name;

        protected override string DbName => "TrainDTrainor";
        protected override string JoinTableName => "tbl" + typeof(TraineeEvaluationVideo).Name + "s";

    }
}
