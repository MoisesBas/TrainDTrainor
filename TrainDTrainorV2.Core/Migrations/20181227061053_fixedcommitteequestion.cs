using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class fixedcommitteequestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCommitteeQuestionEvaluations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    CommitteeId = table.Column<Guid>(nullable: false),
                    TraineeId = table.Column<Guid>(nullable: false),
                    BuildCourseAttendeeId = table.Column<Guid>(nullable: false),
                    CommitteeQuestionId = table.Column<Guid>(nullable: false),
                    Evaluation = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCommitteeQuestionEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeQuestionEvaluations_TrainingCourseAttendee_BuildCourseAttendeeId",
                        column: x => x.BuildCourseAttendeeId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingBuildCourseAttendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TraineeQuestionEvaluations_CommitteeQuestion_CommitteeQuestionId",
                        column: x => x.CommitteeQuestionId,
                        principalSchema: "dbo",
                        principalTable: "tblCommitteeQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCommitteeQuestionEvaluations_BuildCourseAttendeeId",
                schema: "dbo",
                table: "tblCommitteeQuestionEvaluations",
                column: "BuildCourseAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCommitteeQuestionEvaluations_CommitteeQuestionId",
                schema: "dbo",
                table: "tblCommitteeQuestionEvaluations",
                column: "CommitteeQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCommitteeQuestionEvaluations",
                schema: "dbo");
        }
    }
}
