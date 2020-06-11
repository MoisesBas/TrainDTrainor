using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.BaseMigrations
{
    public abstract class DbMigrationBase:Migration
    {
        protected abstract string DbName { get; }        
    }
}
