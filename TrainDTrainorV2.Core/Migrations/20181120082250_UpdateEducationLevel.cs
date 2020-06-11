using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class UpdateEducationLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                schema: "dbo",
                table: "tblUserProfileEducations");

            migrationBuilder.DropColumn(
                name: "To",
                schema: "dbo",
                table: "tblUserProfileEducations");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "dbo",
                table: "tblUserProfileEducations",
                newName: "EducationLevel");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "dbo",
                table: "tblUserProfileEducations",
                nullable: false,
                defaultValue: 0);           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                schema: "dbo",
                table: "tblUserProfileEducations");           

            migrationBuilder.RenameColumn(
                name: "EducationLevel",
                schema: "dbo",
                table: "tblUserProfileEducations",
                newName: "Address");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                schema: "dbo",
                table: "tblUserProfileEducations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                schema: "dbo",
                table: "tblUserProfileEducations",
                nullable: true);
        }
    }
}
