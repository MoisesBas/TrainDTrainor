using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addLevelSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblLevelSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(nullable: true),
                    LevelId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelSubject_tblLevels_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "dbo",
                        principalTable: "tblLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubject_LevelId",
                table: "tblLevelSubjects",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblLevelSubjects");
        }
    }
}
