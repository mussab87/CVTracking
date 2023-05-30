using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: true),
                    MaxMonthLock = table.Column<bool>(type: "bit", nullable: true),
                    MonthLockStatus = table.Column<bool>(type: "bit", nullable: true),
                    UserStatus = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoggedOutDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttachmentTypes_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusNo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVStatuses_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVStatuses_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentTypes_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "AttachmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachments_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCityId = table.Column<int>(type: "int", nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryCityId",
                        column: x => x.CountryCityId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPeriod = table.Column<int>(type: "int", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportDateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportDateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishLanguage = table.Column<bool>(type: "bit", nullable: true),
                    ArabicLanguage = table.Column<bool>(type: "bit", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirthId = table.Column<int>(type: "int", nullable: true),
                    MartialStatus = table.Column<int>(type: "int", nullable: true),
                    NoOfChildren = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVs_Cities_PlaceOfBirthId",
                        column: x => x.PlaceOfBirthId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVs_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVs_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForeignAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignAgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignAgentLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignAgentCountryCityId = table.Column<int>(type: "int", nullable: true),
                    ForeignAgentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignAgentLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignAgentContacts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignAgentComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignAgents_Cities_ForeignAgentCountryCityId",
                        column: x => x.ForeignAgentCountryCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForeignAgents_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForeignAgents_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocalAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalAgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAgentLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAgentCountryCityId = table.Column<int>(type: "int", nullable: true),
                    LocalAgentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAgentLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAgentContacts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAgentComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalAgents_Cities_LocalAgentCountryCityId",
                        column: x => x.LocalAgentCountryCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalAgents_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalAgents_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCompanyCountryCityId = table.Column<int>(type: "int", nullable: true),
                    RootCompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCompanyContacts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCompanyComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootCompanies_Cities_RootCompanyCountryCityId",
                        column: x => x.RootCompanyCountryCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootCompanies_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootCompanies_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVAttachments", x => new { x.CVId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_CVAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVAttachments_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVAttachments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVAttachments_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreviousEmployments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Period = table.Column<int>(type: "int", nullable: false),
                    CountryOfEmploymentId = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEmployments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousEmployments_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreviousEmployments_Countries_CountryOfEmploymentId",
                        column: x => x.CountryOfEmploymentId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreviousEmployments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreviousEmployments_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HRPools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignAgentId = table.Column<int>(type: "int", nullable: true),
                    CVId = table.Column<int>(type: "int", nullable: true),
                    CVStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRPools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRPools_CVStatuses_CVStatusId",
                        column: x => x.CVStatusId,
                        principalTable: "CVStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HRPools_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HRPools_ForeignAgents_ForeignAgentId",
                        column: x => x.ForeignAgentId,
                        principalTable: "ForeignAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HRPools_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HRPools_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootCompanyForeignAgents",
                columns: table => new
                {
                    RootCompanyId = table.Column<int>(type: "int", nullable: false),
                    ForeignAgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCompanyForeignAgents", x => new { x.RootCompanyId, x.ForeignAgentId });
                    table.ForeignKey(
                        name: "FK_RootCompanyForeignAgents_ForeignAgents_ForeignAgentId",
                        column: x => x.ForeignAgentId,
                        principalTable: "ForeignAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootCompanyForeignAgents_RootCompanies_RootCompanyId",
                        column: x => x.RootCompanyId,
                        principalTable: "RootCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootCompanyLocalAgents",
                columns: table => new
                {
                    RootCompanyId = table.Column<int>(type: "int", nullable: false),
                    LocalAgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCompanyLocalAgents", x => new { x.RootCompanyId, x.LocalAgentId });
                    table.ForeignKey(
                        name: "FK_RootCompanyLocalAgents_LocalAgents_LocalAgentId",
                        column: x => x.LocalAgentId,
                        principalTable: "LocalAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootCompanyLocalAgents_RootCompanies_RootCompanyId",
                        column: x => x.RootCompanyId,
                        principalTable: "RootCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootCompanyUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RootCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCompanyUsers", x => new { x.ApplicationUserId, x.RootCompanyId });
                    table.ForeignKey(
                        name: "FK_RootCompanyUsers_RootCompanies_RootCompanyId",
                        column: x => x.RootCompanyId,
                        principalTable: "RootCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootCompanyUsers_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedCvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalAgentId = table.Column<int>(type: "int", nullable: true),
                    HRPoolIDId = table.Column<int>(type: "int", nullable: true),
                    LocalAgentStatusId = table.Column<int>(type: "int", nullable: true),
                    SelectedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootAdminCompanyConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedCvs_CVStatuses_LocalAgentStatusId",
                        column: x => x.LocalAgentStatusId,
                        principalTable: "CVStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedCvs_HRPools_HRPoolIDId",
                        column: x => x.HRPoolIDId,
                        principalTable: "HRPools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedCvs_LocalAgents_LocalAgentId",
                        column: x => x.LocalAgentId,
                        principalTable: "LocalAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedCvs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedCvs_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentTypeId",
                table: "Attachments",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CreatedById",
                table: "Attachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_LastModifiedById",
                table: "Attachments",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTypes_CreatedById",
                table: "AttachmentTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTypes_LastModifiedById",
                table: "AttachmentTypes",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCityId",
                table: "Cities",
                column: "CountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LastModifiedById",
                table: "Cities",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LastModifiedById",
                table: "Countries",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVAttachments_AttachmentId",
                table: "CVAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CVAttachments_CreatedById",
                table: "CVAttachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVAttachments_LastModifiedById",
                table: "CVAttachments",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_CreatedById",
                table: "CVs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_LastModifiedById",
                table: "CVs",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_NationalityId",
                table: "CVs",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_PlaceOfBirthId",
                table: "CVs",
                column: "PlaceOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_CVStatuses_CreatedById",
                table: "CVStatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CVStatuses_LastModifiedById",
                table: "CVStatuses",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_CreatedById",
                table: "ForeignAgents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_ForeignAgentCountryCityId",
                table: "ForeignAgents",
                column: "ForeignAgentCountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignAgents_LastModifiedById",
                table: "ForeignAgents",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_CreatedById",
                table: "HRPools",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_CVId",
                table: "HRPools",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_CVStatusId",
                table: "HRPools",
                column: "CVStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_ForeignAgentId",
                table: "HRPools",
                column: "ForeignAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_HRPools_LastModifiedById",
                table: "HRPools",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_CreatedById",
                table: "LocalAgents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_LastModifiedById",
                table: "LocalAgents",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAgents_LocalAgentCountryCityId",
                table: "LocalAgents",
                column: "LocalAgentCountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_CountryOfEmploymentId",
                table: "PreviousEmployments",
                column: "CountryOfEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_CreatedById",
                table: "PreviousEmployments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_CVId",
                table: "PreviousEmployments",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEmployments_LastModifiedById",
                table: "PreviousEmployments",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_CreatedById",
                table: "RootCompanies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_LastModifiedById",
                table: "RootCompanies",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanies_RootCompanyCountryCityId",
                table: "RootCompanies",
                column: "RootCompanyCountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanyForeignAgents_ForeignAgentId",
                table: "RootCompanyForeignAgents",
                column: "ForeignAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanyLocalAgents_LocalAgentId",
                table: "RootCompanyLocalAgents",
                column: "LocalAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCompanyUsers_RootCompanyId",
                table: "RootCompanyUsers",
                column: "RootCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_CreatedById",
                table: "SelectedCvs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_HRPoolIDId",
                table: "SelectedCvs",
                column: "HRPoolIDId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_LastModifiedById",
                table: "SelectedCvs",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_LocalAgentId",
                table: "SelectedCvs",
                column: "LocalAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCvs_LocalAgentStatusId",
                table: "SelectedCvs",
                column: "LocalAgentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CVAttachments");

            migrationBuilder.DropTable(
                name: "PreviousEmployments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RootCompanyForeignAgents");

            migrationBuilder.DropTable(
                name: "RootCompanyLocalAgents");

            migrationBuilder.DropTable(
                name: "RootCompanyUsers");

            migrationBuilder.DropTable(
                name: "SelectedCvs");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "UserTransaction");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "RootCompanies");

            migrationBuilder.DropTable(
                name: "HRPools");

            migrationBuilder.DropTable(
                name: "LocalAgents");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AttachmentTypes");

            migrationBuilder.DropTable(
                name: "CVStatuses");

            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.DropTable(
                name: "ForeignAgents");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
