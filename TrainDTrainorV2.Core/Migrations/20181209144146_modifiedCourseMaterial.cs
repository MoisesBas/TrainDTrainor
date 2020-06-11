using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class modifiedCourseMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialMongoDbId",
                schema: "dbo",
                table: "tblCourseMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                schema: "dbo",
                table: "tblCourseMaterial",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EvaluationVideoPicFiletable",
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
                    table.PrimaryKey("PK_EvaluationVideoPicFiletable", x => x.Stream_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationVideoPicFiletable");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "dbo",
                table: "tblCourseMaterial");

            migrationBuilder.AddColumn<string>(
                name: "MaterialMongoDbId",
                schema: "dbo",
                table: "tblCourseMaterial",
                maxLength: 50,
                nullable: true);
        }
    }
}
