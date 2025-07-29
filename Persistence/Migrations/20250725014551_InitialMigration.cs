using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    StreetAddress1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StreetAddress2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Province = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    County = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    FullAddress = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMs = table.Column<long>(type: "bigint", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    EventType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TableName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RecordId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HttpMethod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Endpoint = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    OldValues = table.Column<string>(type: "varchar(MAX)", unicode: false, nullable: true),
                    NewValues = table.Column<string>(type: "varchar(MAX)", unicode: false, nullable: true),
                    ChangedColumns = table.Column<string>(type: "varchar(MAX)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LockOutEnd = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    LockOutEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    RefreshToken = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LvAddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(9999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvAddressTypes", x => new { x.Id, x.Code });
                    table.UniqueConstraint("AK_LvAddressTypes_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LvContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(9999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvContactTypes", x => new { x.Id, x.Code });
                    table.UniqueConstraint("AK_LvContactTypes_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LvVerificationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(9999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvVerificationType", x => new { x.Id, x.Code });
                    table.UniqueConstraint("AK_LvVerificationType_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NormalizedName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ClaimValue = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityClaim_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsIndividual = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    RemovedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityInformation_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityLogin", x => new { x.EntityId, x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_EntityLogin_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityToken",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityToken", x => new { x.EntityId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_EntityToken_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    VerificationCodeType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "getutcdate()"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, computedColumnSql: "DATEADD(minute, 15, CreatedDate)"),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AdditionalData = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    FailedAttempt = table.Column<short>(type: "smallint", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationCodes_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificationCodes_LvVerificationType_VerificationCodeType",
                        column: x => x.VerificationCodeType,
                        principalTable: "LvVerificationType",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "EntityRole",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRole", x => new { x.EntityId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EntityRole_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ClaimValue = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    RemovedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAddress", x => new { x.Id, x.EntityId, x.AddressId, x.AddressTypeCode });
                    table.ForeignKey(
                        name: "FK_EntityAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityAddress_EntityInformation_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityAddress_LvAddressTypes_AddressTypeCode",
                        column: x => x.AddressTypeCode,
                        principalTable: "LvAddressTypes",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "EntityContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    EntityInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Value = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    RemovedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityContact", x => new { x.Id, x.EntityInformationId, x.ContactTypeCode });
                    table.ForeignKey(
                        name: "FK_EntityContact_EntityInformation_EntityInformationId",
                        column: x => x.EntityInformationId,
                        principalTable: "EntityInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityContact_LvContactTypes_ContactTypeCode",
                        column: x => x.ContactTypeCode,
                        principalTable: "LvContactTypes",
                        principalColumn: "Code");
                });

            migrationBuilder.InsertData(
                table: "LvAddressTypes",
                columns: new[] { "Code", "Id", "Description", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "HOME", 1, "Home", "Home", (short)10 },
                    { "WORK", 2, "Work", "Work", (short)20 },
                    { "BILL", 3, "Billing", "Billing", (short)30 },
                    { "SHIP", 4, "Shipping", "Shipping", (short)40 },
                    { "OTH", 5, "Other", "Other", (short)50 }
                });

            migrationBuilder.InsertData(
                table: "LvContactTypes",
                columns: new[] { "Code", "Id", "Description", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "EML", 1, "Email", "Email", (short)10 },
                    { "PHN", 2, "Phone", "Phone", (short)20 },
                    { "MBL", 3, "Mobile", "Mobile", (short)30 },
                    { "FAX", 4, "Fax", "Fax", (short)40 },
                    { "WEB", 5, "Website", "Website", (short)50 },
                    { "FB", 6, "Facebook", "Facebook", (short)60 },
                    { "X", 7, "X", "X", (short)70 },
                    { "INSTG", 8, "Instagram", "Instagram", (short)80 },
                    { "OTH", 9, "Other", "Other", (short)90 }
                });

            migrationBuilder.InsertData(
                table: "LvVerificationType",
                columns: new[] { "Code", "Id", "Description", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "2FAV", 1, "Two Factor Authentication", "Two Factor Authentication", (short)10 },
                    { "EMLV", 2, "Email Veiriication", "Email Verification", (short)20 },
                    { "PHV", 3, "Phone Verification", "Phone Verification", (short)30 },
                    { "PWDV", 4, "Password Reset Verification", "Password Reset Verification", (short)40 },
                    { "ACCV", 5, "Account Recovery Verification", "Account Recovery Verification", (short)50 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "d188567a-4bdf-439a-8f02-b1df7ca791c6", "Administrator", "ADMINISTRATOR" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "accdb00c-13dc-47e4-a400-939998b7b9d7", "Manager", "MANAGER" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "28d2028c-7382-4f4c-9667-951ce7493ebd", "User", "USER" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "908dd5cf-625e-4a71-b9d9-95aa0ebefca4", "Guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppLog_Timestamp_Level_Logger_UserId_CorrelationId",
                table: "AppLog",
                columns: new[] { "Timestamp", "Level", "Logger", "UserId", "CorrelationId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_Timestamp_EventType_TableName_UserId",
                table: "AuditLog",
                columns: new[] { "Timestamp", "EventType", "TableName", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_NormalizedEmail",
                table: "Entity",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_NormalizedUserName",
                table: "Entity",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddress_AddressId",
                table: "EntityAddress",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddress_AddressTypeCode",
                table: "EntityAddress",
                column: "AddressTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddress_EntityId",
                table: "EntityAddress",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityClaim_EntityId",
                table: "EntityClaim",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityContact_ContactTypeCode",
                table: "EntityContact",
                column: "ContactTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EntityContact_EntityInformationId",
                table: "EntityContact",
                column: "EntityInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityInformation_EntityId",
                table: "EntityInformation",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityRole_RoleId",
                table: "EntityRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_NormalizedName",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_Code_EntityId_VerificationCodeType",
                table: "VerificationCodes",
                columns: new[] { "Code", "EntityId", "VerificationCodeType" });

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_EntityId",
                table: "VerificationCodes",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_VerificationCodeType",
                table: "VerificationCodes",
                column: "VerificationCodeType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLog");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "EntityAddress");

            migrationBuilder.DropTable(
                name: "EntityClaim");

            migrationBuilder.DropTable(
                name: "EntityContact");

            migrationBuilder.DropTable(
                name: "EntityLogin");

            migrationBuilder.DropTable(
                name: "EntityRole");

            migrationBuilder.DropTable(
                name: "EntityToken");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "VerificationCodes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "LvAddressTypes");

            migrationBuilder.DropTable(
                name: "EntityInformation");

            migrationBuilder.DropTable(
                name: "LvContactTypes");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "LvVerificationType");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
