using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class UpdateWorkHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.DropColumn(
                name: "To",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.DropColumn(
                name: "JobField",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.DropColumn(
                name: "UserProfileJobHistory_To",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.DropColumn(
                name: "WorkType",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.AddColumn<int>(
                name: "Years",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Years",
                schema: "dbo",
                table: "tblUserProfileJobHistories");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobField",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UserProfileJobHistory_To",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                maxLength: 90,
                nullable: true);
        }
    }
}
