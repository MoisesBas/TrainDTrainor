using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class addPaymentTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
               name: "IX_tblPaymentTransactions_TrainingId",
               schema: "dbo",
               table: "tblPaymentTransactions");

            migrationBuilder.DropForeignKey(
             name: "FK_PaymentTransactions_Training_TrainingId",
             schema: "dbo",
             table: "tblPaymentTransactions");

            migrationBuilder.DropColumn(
               name: "TrainingId",
               schema: "dbo",
               table: "tblPaymentTransactions");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "tblPaymentTransactions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tblPaymentTransactionHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    CourseId = table.Column<Guid>(nullable: false),
                    PaymentTransactionId = table.Column<Guid>(nullable: false),
                    UserProfileId = table.Column<Guid>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Comments = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaymentTransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPaymentTransactionHistory_tblTrainingCourses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_PaymentTransactionHistories_PaymentTransactionId",
                        column: x => x.PaymentTransactionId,
                        principalSchema: "dbo",
                        principalTable: "tblPaymentTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPaymentTransactionHistory_tblUserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactions_CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactionHistory_CourseId",
                schema: "dbo",
                table: "tblPaymentTransactionHistory",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactionHistory_PaymentTransactionId",
                schema: "dbo",
                table: "tblPaymentTransactionHistory",
                column: "PaymentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactionHistory_UserProfileId",
                schema: "dbo",
                table: "tblPaymentTransactionHistory",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Course_CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions",
                column: "CourseId",
                principalSchema: "dbo",
                principalTable: "tblTrainingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Course_CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions");

            migrationBuilder.DropTable(
                name: "tblPaymentTransactionHistory",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_tblPaymentTransactions_CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "tblPaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                schema: "dbo",
                table: "tblPaymentTransactions");            
        }
    }
}
