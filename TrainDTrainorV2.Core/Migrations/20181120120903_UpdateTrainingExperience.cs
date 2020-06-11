using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class UpdateTrainingExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExperience_tblUserProfiles_UserProfileId",
                table: "TrainingExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExperience",
                table: "TrainingExperience");

            migrationBuilder.RenameTable(
                name: "TrainingExperience",
                newName: "tblUserTrainingExperience",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExperience_UserProfileId",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                newName: "IX_tblUserTrainingExperience_UserProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Updated",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                nullable: false,
                defaultValueSql: "(sysutcdatetime())",
                oldClrType: typeof(DateTimeOffset));           

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                nullable: false,
                defaultValueSql: "(sysutcdatetime())",
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserTrainingExperience",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExperiences_UserProfile_UserProfileId",
                schema: "dbo",
                table: "tblUserTrainingExperience",
                column: "UserProfileId",
                principalSchema: "dbo",
                principalTable: "tblUserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExperiences_UserProfile_UserProfileId",
                schema: "dbo",
                table: "tblUserTrainingExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserTrainingExperience",
                schema: "dbo",
                table: "tblUserTrainingExperience");

            migrationBuilder.RenameTable(
                name: "tblUserTrainingExperience",
                schema: "dbo",
                newName: "TrainingExperience");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserTrainingExperience_UserProfileId",
                table: "TrainingExperience",
                newName: "IX_TrainingExperience_UserProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Updated",
                table: "TrainingExperience",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValueSql: "(sysutcdatetime())");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 8,
                oldRowVersion: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "TrainingExperience",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValueSql: "(sysutcdatetime())");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "TrainingExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExperience",
                table: "TrainingExperience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExperience_tblUserProfiles_UserProfileId",
                table: "TrainingExperience",
                column: "UserProfileId",
                principalSchema: "dbo",
                principalTable: "tblUserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
