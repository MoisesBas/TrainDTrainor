using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class UpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country ",
                schema: "dbo",
                table: "tblUserProfiles",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "City ",
                schema: "dbo",
                table: "tblUserProfiles",
                maxLength: 190,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 190);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country ",
                schema: "dbo",
                table: "tblUserProfiles",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City ",
                schema: "dbo",
                table: "tblUserProfiles",
                maxLength: 190,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 190,
                oldNullable: true);
        }
    }
}
