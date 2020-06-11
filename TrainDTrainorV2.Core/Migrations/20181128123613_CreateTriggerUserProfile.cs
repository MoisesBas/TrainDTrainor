using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class CreateTriggerUserProfile : Migration
    {
        private string TableName => "tbl" + typeof(UserProfile).Name + "s";
        private string FileTableName => typeof(TrainDTrainorV2.Core.Data.Entities.UserProfilePic).Name;
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.Trigger_Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            this.Trigger_Down(migrationBuilder);
        }

        public void Trigger_Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"
                CREATE TRIGGER [{0}_DeleteFileTable] ON 
                [dbo].[{0}] AFTER DELETE AS
                BEGIN                 
                DELETE l 
                FROM [dbo].[{1}] l
                INNER JOIN deleted p on p.FileId = l.stream_id;          
                END;", TableName, FileTableName));
        }
        public void Trigger_Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(string.Format(@"DROP TRIGGER [{0}_DeleteFileTable];", TableName));
        }
    }
}
