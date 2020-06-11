using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addRoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "dbo",
                table: "tblUserRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MaxAttendee",
                schema: "dbo",
                table: "tblTrainingCourses",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NoAttendee",
                schema: "dbo",
                table: "tblTrainingCourses",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "dbo",
                table: "tblUserRoles");

            migrationBuilder.DropColumn(
                name: "NoAttendee",
                schema: "dbo",
                table: "tblTrainingCourses");

            migrationBuilder.AlterColumn<int>(
                name: "MaxAttendee",
                schema: "dbo",
                table: "tblTrainingCourses",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }
    }
}
