using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addIsActiveTrainingBuildCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourseAttendees_TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                column: "TrainingBuildCourseParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingBuildCourseAttendees_TrainingCourseAttendee_TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                column: "TrainingBuildCourseParentId",
                principalSchema: "dbo",
                principalTable: "tblTrainingBuildCourseAttendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingBuildCourseAttendees_TrainingCourseAttendee_TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees");

            migrationBuilder.DropIndex(
                name: "IX_tblTrainingBuildCourseAttendees_TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees");

            migrationBuilder.DropColumn(
                name: "TrainingBuildCourseParentId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees");
        }
    }
}
