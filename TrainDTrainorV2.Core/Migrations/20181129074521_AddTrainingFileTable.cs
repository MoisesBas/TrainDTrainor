using System;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class AddTrainingFileTable : CreateFiletable
    {
        protected override string TableName => typeof(TrainingVideoPic).Name;

        protected override string DbName => "TrainDTrainor";
        protected override string JoinTableName => "tbl" + typeof(TrainingVideo).Name + "s";
    }
}
