using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class modifiedcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "tblTrainingCourses",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                schema: "dbo",
                table: "tblTrainingCourses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocationMap",
                schema: "dbo",
                table: "tblTrainingCourses",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                schema: "dbo",
                table: "tblTrainingCourses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CourseMaterialPicFiletable",
                columns: table => new
                {
                    Stream_id = table.Column<Guid>(nullable: false),
                    File_stream = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ParentPath = table.Column<string>(nullable: true),
                    Creation_time = table.Column<DateTimeOffset>(nullable: false),
                    Last_write_time = table.Column<DateTimeOffset>(nullable: false),
                    Last_access_time = table.Column<DateTimeOffset>(nullable: false),
                    Is_directory = table.Column<bool>(nullable: false),
                    Is_offline = table.Column<bool>(nullable: false),
                    Is_hidden = table.Column<bool>(nullable: false),
                    Is_readonly = table.Column<bool>(nullable: false),
                    Is_archive = table.Column<bool>(nullable: false),
                    Is_system = table.Column<bool>(nullable: false),
                    Is_temporary = table.Column<bool>(nullable: false),
                    fullpath = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterialPicFiletable", x => x.Stream_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterialPicFiletable");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "tblTrainingCourses");

            migrationBuilder.DropColumn(
                name: "From",
                schema: "dbo",
                table: "tblTrainingCourses");

            migrationBuilder.DropColumn(
                name: "LocationMap",
                schema: "dbo",
                table: "tblTrainingCourses");

            migrationBuilder.DropColumn(
                name: "To",
                schema: "dbo",
                table: "tblTrainingCourses");
        }
    }
}
