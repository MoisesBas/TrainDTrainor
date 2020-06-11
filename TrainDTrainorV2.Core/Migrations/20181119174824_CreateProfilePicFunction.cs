using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class CreateProfilePicFunction : CreateFiletable
    {
        
        protected override string TableName => typeof(UserProfilePic).Name;
        protected override string DbName => "TrainDTrainor";
        protected override string JoinTableName => "tbl" + typeof(UserProfile).Name + "s";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.View_Down(migrationBuilder);
            this.Function_Down(migrationBuilder);
            this.Function_Up(migrationBuilder);
            this.View_Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            this.View_Up(migrationBuilder);
            this.Function_Down(migrationBuilder);
            this.View_Down(migrationBuilder);
        }
    }
}
