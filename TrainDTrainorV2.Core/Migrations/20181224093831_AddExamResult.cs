using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class AddExamResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblTraineeExamResults",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    UserId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(maxLength: 100, nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTraineeExamResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResults_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeExamResults_CourseId",
                schema: "dbo",
                table: "tblTraineeExamResults",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeExamResults_QuestionId",
                schema: "dbo",
                table: "tblTraineeExamResults",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeExamResults_UserId",
                schema: "dbo",
                table: "tblTraineeExamResults",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblTraineeExamResults",
                schema: "dbo");
        }
    }
}
