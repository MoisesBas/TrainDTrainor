using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class UpdateTrainingExperienceByUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserTrainingExperience",
                schema: "dbo",
                table: "tblUserTrainingExperience");

            migrationBuilder.RenameTable(
                name: "tblUserTrainingExperience",
                schema: "dbo",
                newName: "tblUserProfileTrainingExperience",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserTrainingExperience_UserProfileId",
                schema: "dbo",
                table: "tblUserProfileTrainingExperience",
                newName: "IX_tblUserProfileTrainingExperience_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserProfileTrainingExperience",
                schema: "dbo",
                table: "tblUserProfileTrainingExperience",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserProfileTrainingExperience",
                schema: "dbo",
                table: "tblUserProfileTrainingExperience");

            migrationBuilder.RenameTable(
                name: "tblUserProfileTrainingExperience",
                schema: "dbo",
                newName: "tblUserTrainingExperience",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserProfileTrainingExperience_UserProfileId",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                newName: "IX_tblUserTrainingExperience_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserTrainingExperience",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                column: "Id");
        }
    }
}
