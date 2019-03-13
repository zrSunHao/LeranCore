using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class InitialEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basic");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.CreateTable(
                name: "Occupation",
                schema: "basic",
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
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "basic",
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
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "system",
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    TagColor = table.Column<string>(maxLength: 50, nullable: false),
                    Icon = table.Column<string>(maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Intro = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "system",
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
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                schema: "system",
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    TagColor = table.Column<string>(maxLength: 50, nullable: false),
                    Icon = table.Column<string>(maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Intro = table.Column<string>(maxLength: 200, nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                schema: "system",
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
                    table.PrimaryKey("PK_ProfilePicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prompt",
                schema: "system",
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
                    table.PrimaryKey("PK_Prompt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "system",
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
                    Intro = table.Column<string>(maxLength: 200, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                schema: "system",
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
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "system",
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Intro = table.Column<string>(maxLength: 200, nullable: false),
                    Icon = table.Column<string>(maxLength: 100, nullable: false),
                    TagColor = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Page_PageId",
                        column: x => x.PageId,
                        principalSchema: "system",
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "system",
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
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "system",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "system",
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
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    PageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "system",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("917cfe90-a330-4a06-a3ba-577fe4418568"), false, new DateTime(2019, 3, 13, 14, 56, 52, 552, DateTimeKind.Local).AddTicks(6581), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("3711b967-cfb8-4e48-9db6-551ad2d48a31"), false, new DateTime(2019, 3, 13, 14, 56, 52, 553, DateTimeKind.Local).AddTicks(6072), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("6d494fed-e660-42ce-89c5-27699e2dadcd"), false, new DateTime(2019, 3, 13, 14, 56, 52, 553, DateTimeKind.Local).AddTicks(6079), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                schema: "system",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PageId",
                schema: "system",
                table: "Permission",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                schema: "system",
                table: "RolePermission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupation",
                schema: "basic");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "basic");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "system");

            migrationBuilder.DropTable(
                name: "ProfilePicture",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Prompt",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "system");

            migrationBuilder.DropTable(
                name: "UserInfo",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Page",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "system");
        }
    }
}
