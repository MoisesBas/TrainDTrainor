using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class EditLevelRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                schema: "dbo",
                table: "tblLevels",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));            

            migrationBuilder.CreateIndex(
                name: "IX_tblLevels_TrainingId",
                schema: "dbo",
                table: "tblLevels",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Training_TrainingId",
                schema: "dbo",
                table: "tblLevels",
                column: "TrainingId",
                principalSchema: "dbo",
                principalTable: "tblTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Training_TrainingId",
                schema: "dbo",
                table: "tblLevels");      

            migrationBuilder.DropIndex(
                name: "IX_tblLevels_TrainingId",
                schema: "dbo",
                table: "tblLevels");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                schema: "dbo",
                table: "tblLevels");         

           
        }
    }
}
