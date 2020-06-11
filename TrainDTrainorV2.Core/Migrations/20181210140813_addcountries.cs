using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addcountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCountry",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCountry",
                schema: "dbo");
        }
    }
}
