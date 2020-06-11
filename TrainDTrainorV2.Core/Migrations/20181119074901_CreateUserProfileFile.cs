using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class CreateUserProfileFile : CreateFiletable
    {
        protected override string TableName => typeof(UserProfilePic).Name;

        protected override string DbName => "TrainDTrainor";
        protected override string JoinTableName => "tbl" + typeof(UserProfile).Name + "s";
    }
}
