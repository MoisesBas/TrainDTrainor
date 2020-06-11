using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addVideoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDesktop",
                schema: "dbo",
                table: "tblLevelVideos",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "IsMobile",
                schema: "dbo",
                table: "tblLevelVideos",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
               name: "IsDesktop",
               schema: "dbo",
               table: "tblTrainingVideos",
               nullable: false,
               defaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "IsMobile",
                schema: "dbo",
                table: "tblTrainingVideos",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDesktop",
                schema: "dbo",
                table: "tblLevelVideos");

            migrationBuilder.DropColumn(
                name: "IsMobile",
                schema: "dbo",
                table: "tblLevelVideos");

            migrationBuilder.DropColumn(
               name: "IsDesktop",
               schema: "dbo",
               table: "tblTrainingVideos");

            migrationBuilder.DropColumn(
                name: "IsMobile",
                schema: "dbo",
                table: "tblTrainingVideos");
        }
    }
}
