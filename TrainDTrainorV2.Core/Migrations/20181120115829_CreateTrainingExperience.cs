using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class CreateTrainingExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Attended = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    UserProfileId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingExperience_tblUserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExperience_UserProfileId",
                table: "TrainingExperience",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExperience");
        }
    }
}
