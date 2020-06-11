using System;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class ConfigureFileDatabase : InitDb
    {
        public override string RootPath => @"E:\TrainDTrainorDbs";

        protected override string DbName => "TrainDTrainor";
    }
}
