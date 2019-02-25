using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Basic");

            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.CreateTable(
                name: "Occupations",
                schema: "Basic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ParentCode = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupations_Occupations_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Basic",
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "Basic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegionCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ParentCode = table.Column<int>(nullable: true),
                    LayerLevel = table.Column<int>(nullable: false),
                    CityCode = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    MergerName = table.Column<string>(maxLength: 150, nullable: true),
                    Lng = table.Column<float>(maxLength: 60, nullable: false),
                    Lat = table.Column<float>(maxLength: 60, nullable: false),
                    PinYin = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Regions_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Basic",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "System",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePictures",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(maxLength: 100, nullable: true),
                    FileType = table.Column<string>(maxLength: 20, nullable: true),
                    Url = table.Column<string>(maxLength: 200, nullable: true),
                    FileLength = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Intro = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    OccupationId = table.Column<Guid>(nullable: false),
                    Intro = table.Column<string>(maxLength: 400, nullable: true),
                    ProfilePictureId = table.Column<Guid>(nullable: true),
                    PhoneNum = table.Column<string>(maxLength: 20, nullable: true),
                    QQ = table.Column<string>(maxLength: 20, nullable: true),
                    WeChart = table.Column<string>(maxLength: 50, nullable: true),
                    BaseAddressId = table.Column<Guid>(nullable: false),
                    CurrentAddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Regions_CurrentAddressId",
                        column: x => x.CurrentAddressId,
                        principalSchema: "Basic",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInfos_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalSchema: "Basic",
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Info = table.Column<string>(maxLength: 200, nullable: false),
                    LastInfo = table.Column<string>(maxLength: 200, nullable: false),
                    UpdateNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "System",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    RefreshToken = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    LatestLoginAt = table.Column<DateTime>(nullable: true),
                    Forbiden = table.Column<bool>(nullable: false),
                    LockoutEndAt = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleOrgItems",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOrgItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleOrgItems_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_Code",
                schema: "Basic",
                table: "Occupations",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_ParentId",
                schema: "Basic",
                table: "Occupations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LayerLevel",
                schema: "Basic",
                table: "Regions",
                column: "LayerLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentId",
                schema: "Basic",
                table: "Regions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionCode",
                schema: "Basic",
                table: "Regions",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                schema: "System",
                table: "Accounts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                schema: "System",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentId",
                schema: "System",
                table: "Organizations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_Code",
                schema: "System",
                table: "Prompts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_OrganizationId",
                schema: "System",
                table: "Prompts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOrgItems_RoleId",
                schema: "System",
                table: "RoleOrgItems",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_AccountId",
                schema: "System",
                table: "UserInfos",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_CurrentAddressId",
                schema: "System",
                table: "UserInfos",
                column: "CurrentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_OccupationId",
                schema: "System",
                table: "UserInfos",
                column: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "System");

            migrationBuilder.DropTable(
                name: "ProfilePictures",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Prompts",
                schema: "System");

            migrationBuilder.DropTable(
                name: "RoleOrgItems",
                schema: "System");

            migrationBuilder.DropTable(
                name: "UserInfos",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "System");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "Basic");

            migrationBuilder.DropTable(
                name: "Occupations",
                schema: "Basic");
        }
    }
}
