using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class InitialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tblEmailDeliverys",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    IsProcessing = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelivered = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Delivered = table.Column<DateTimeOffset>(nullable: true),
                    Attempts = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    LastAttempt = table.Column<DateTimeOffset>(nullable: true),
                    NextAttempt = table.Column<DateTimeOffset>(nullable: true),
                    SmtpLog = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    From = table.Column<string>(maxLength: 265, nullable: true),
                    To = table.Column<string>(maxLength: 265, nullable: true),
                    Subject = table.Column<string>(maxLength: 265, nullable: true),
                    MimeMessage = table.Column<byte[]>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmailDeliverys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmailTemplates",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    FromAddress = table.Column<string>(maxLength: 256, nullable: false),
                    FromName = table.Column<string>(maxLength: 256, nullable: false),
                    ReplyToAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ReplyToName = table.Column<string>(maxLength: 256, nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    TextBody = table.Column<string>(nullable: true),
                    HtmlBody = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLevels",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSMSDeliveries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    IsProcessing = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelivered = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Delivered = table.Column<DateTimeOffset>(nullable: true),
                    Attempts = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    LastAttempt = table.Column<DateTimeOffset>(nullable: true),
                    NextAttempt = table.Column<DateTimeOffset>(nullable: true),
                    SMSLog = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    From = table.Column<string>(maxLength: 265, nullable: true),
                    To = table.Column<string>(maxLength: 265, nullable: true),
                    Message = table.Column<string>(maxLength: 265, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSMSDeliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSMSTemplates",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    TextBody = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSMSTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTrainings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    IsEmailAddressConfirmed = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    ResetHash = table.Column<string>(nullable: true),
                    InviteHash = table.Column<string>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsGlobalAdministrator = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsAgree = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    OTP = table.Column<string>(nullable: true, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLevelQuestions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    QuestionType = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_tblLevelQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelQuestions_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "dbo",
                        principalTable: "tblLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblLevelVideos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    LevelId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLevelVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelVideos_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "dbo",
                        principalTable: "tblLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTrainingVideos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FileId = table.Column<Guid>(nullable: true),
                    TrainingId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainingVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingVideos_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRefreshToken",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    TokenHashed = table.Column<string>(maxLength: 256, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    ClientId = table.Column<string>(maxLength: 450, nullable: true),
                    ProtectedTicket = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Issued = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    Expires = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTrainingCourses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Objectives = table.Column<string>(maxLength: 256, nullable: true),
                    TrainorId = table.Column<Guid>(nullable: true),
                    TrainingId = table.Column<Guid>(nullable: true),
                    CalendarYear = table.Column<short>(nullable: false, defaultValueSql: "(datepart(year,getdate()))"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainingCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCourses_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourses_Trainor_TrainorId",
                        column: x => x.TrainorId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(maxLength: 256, nullable: true),
                    OperatingSystem = table.Column<string>(maxLength: 256, nullable: true),
                    DeviceFamily = table.Column<string>(maxLength: 256, nullable: true),
                    DeviceBrand = table.Column<string>(maxLength: 256, nullable: true),
                    DeviceModel = table.Column<string>(maxLength: 256, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 50, nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    FailureMessage = table.Column<string>(maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserProfiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    FullName = table.Column<string>(name: "FullName ", maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    Age = table.Column<int>(maxLength: 10, nullable: false),
                    Country = table.Column<string>(name: "Country ", maxLength: 150, nullable: false),
                    City = table.Column<string>(name: "City ", maxLength: 190, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 256, nullable: true),
                    BusinessPhone = table.Column<string>(maxLength: 50, nullable: true),
                    FileId = table.Column<Guid>(nullable: true),
                    MongoDbProfileCVId = table.Column<string>(maxLength: 90, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "tblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCourseMaterial",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    MaterialMongoDbId = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourseMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMaterials_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTrainingBuildCourseAttendees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    AttendeeId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainingBuildCourseAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTrainingBuildCourseAttendees_tblUsers_AttendeeId",
                        column: x => x.AttendeeId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTrainingBuildCourseAttendees_tblTrainingCourses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTrainingBuildCourses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    CourseId = table.Column<Guid>(nullable: false),
                    LevelId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrainingBuildCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBuildCourses_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingBuildCourses_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "dbo",
                        principalTable: "tblLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingBuildCourses_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "tblLevelQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPaymentTransactions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    TrainingId = table.Column<Guid>(nullable: true),
                    UserProfileId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserProfileAchievements",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    UserProfileId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserProfileAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserProfileEducations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    UserProfileId = table.Column<Guid>(nullable: true),
                    DegreeName = table.Column<string>(maxLength: 256, nullable: false),
                    NameOfInstitute = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(maxLength: 256, nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserProfileEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserProfileJobHistories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    UserProfileId = table.Column<Guid>(nullable: false),
                    JobField = table.Column<string>(maxLength: 150, nullable: true),
                    WorkType = table.Column<string>(maxLength: 90, nullable: true),
                    Position = table.Column<string>(maxLength: 150, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 150, nullable: true),
                    CompanyAddress = table.Column<string>(maxLength: 150, nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    UserProfileJobHistory_To = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserProfileJobHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobHistories_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "dbo",
                        principalTable: "tblUserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTraineeEvaluationVideos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    FileId = table.Column<Guid>(nullable: true),
                    TrainingBuildCourseAttendeeId = table.Column<Guid>(nullable: false),
                    CourseLevelId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTraineeEvaluationVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTraineeEvaluationVideos_tblLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalSchema: "dbo",
                        principalTable: "tblLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TraineeEvaluationVideos_TrainingBuildCourseAttendee_TrainingBuildCourseAttendeeId",
                        column: x => x.TrainingBuildCourseAttendeeId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingBuildCourseAttendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTraineeEvaluations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    TrainingCourseAttendeeId = table.Column<Guid>(nullable: false),
                    EvaluatorId = table.Column<Guid>(nullable: false),
                    TrainingBuildCourseId = table.Column<Guid>(nullable: true),
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
                    table.PrimaryKey("PK_tblTraineeEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTraineeEvaluations_tblUsers_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalSchema: "dbo",
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTraineeEvaluations_tblTrainingBuildCourses_TrainingBuildCourseId",
                        column: x => x.TrainingBuildCourseId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingBuildCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTraineeEvaluations_tblTrainingBuildCourseAttendees_TrainingCourseAttendeeId",
                        column: x => x.TrainingCourseAttendeeId,
                        principalSchema: "dbo",
                        principalTable: "tblTrainingBuildCourseAttendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCourseMaterial_CourseId",
                schema: "dbo",
                table: "tblCourseMaterial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLevelQuestions_LevelId",
                schema: "dbo",
                table: "tblLevelQuestions",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLevelVideos_LevelId",
                schema: "dbo",
                table: "tblLevelVideos",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactions_TrainingId",
                schema: "dbo",
                table: "tblPaymentTransactions",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPaymentTransactions_UserProfileId",
                schema: "dbo",
                table: "tblPaymentTransactions",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRefreshToken_UserId",
                schema: "dbo",
                table: "tblRefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeEvaluations_EvaluatorId",
                schema: "dbo",
                table: "tblTraineeEvaluations",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeEvaluations_TrainingBuildCourseId",
                schema: "dbo",
                table: "tblTraineeEvaluations",
                column: "TrainingBuildCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeEvaluations_TrainingCourseAttendeeId",
                schema: "dbo",
                table: "tblTraineeEvaluations",
                column: "TrainingCourseAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeEvaluationVideos_CourseLevelId",
                schema: "dbo",
                table: "tblTraineeEvaluationVideos",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraineeEvaluationVideos_TrainingBuildCourseAttendeeId",
                schema: "dbo",
                table: "tblTraineeEvaluationVideos",
                column: "TrainingBuildCourseAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourseAttendees_AttendeeId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourseAttendees_CourseId",
                schema: "dbo",
                table: "tblTrainingBuildCourseAttendees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourses_CourseId",
                schema: "dbo",
                table: "tblTrainingBuildCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourses_LevelId",
                schema: "dbo",
                table: "tblTrainingBuildCourses",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingBuildCourses_QuestionId",
                schema: "dbo",
                table: "tblTrainingBuildCourses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingCourses_TrainingId",
                schema: "dbo",
                table: "tblTrainingCourses",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingCourses_TrainorId",
                schema: "dbo",
                table: "tblTrainingCourses",
                column: "TrainorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrainingVideos_TrainingId",
                schema: "dbo",
                table: "tblTrainingVideos",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserLogins_UserId",
                schema: "dbo",
                table: "tblUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfileAchievements_UserProfileId",
                schema: "dbo",
                table: "tblUserProfileAchievements",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfileEducations_UserProfileId",
                schema: "dbo",
                table: "tblUserProfileEducations",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfileJobHistories_UserProfileId",
                schema: "dbo",
                table: "tblUserProfileJobHistories",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfiles_UserId",
                schema: "dbo",
                table: "tblUserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_RoleId",
                schema: "dbo",
                table: "tblUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_UserId",
                schema: "dbo",
                table: "tblUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "tblCourseMaterial",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblEmailDeliverys",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblEmailTemplates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblLevelVideos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblPaymentTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblRefreshToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblSMSDeliveries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblSMSTemplates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTraineeEvaluations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTraineeEvaluationVideos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTrainingVideos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserProfileAchievements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserProfileEducations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserProfileJobHistories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTrainingBuildCourses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTrainingBuildCourseAttendees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUserProfiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblLevelQuestions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTrainingCourses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblLevels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblTrainings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblUsers",
                schema: "dbo");
        }
    }
}
