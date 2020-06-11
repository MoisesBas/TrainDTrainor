using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class CreateLevelFileTable : CreateFiletable
    {
        protected override string TableName => typeof(LevelVideoPic).Name;

        protected override string DbName => "TrainDTrainor";

        protected override string JoinTableName => "tbl" + typeof(LevelVideo).Name + "s";
    }
}
