using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class updateRolePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPermissions",
                schema: "System");

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("25a0ded5-e752-4bbe-acde-c3978272d74d"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("37a9acb7-340a-4a5e-ba98-14633ea504a7"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("67f066c6-e884-46f8-8a1d-4e009171d878"));

            migrationBuilder.CreateTable(
                name: "RolePermissions",
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
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("03658210-23cc-44e6-9b77-1d56e6cb6a9b"), "SuperAdmin", new DateTime(2019, 2, 25, 10, 36, 40, 895, DateTimeKind.Local).AddTicks(240), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("0125afe0-195b-4aae-8003-d12f69495840"), "Admin", new DateTime(2019, 2, 25, 10, 36, 40, 895, DateTimeKind.Local).AddTicks(9893), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("7bc3bd23-379b-4bdf-9367-b0e05afaf50f"), "User", new DateTime(2019, 2, 25, 10, 36, 40, 895, DateTimeKind.Local).AddTicks(9900), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                schema: "System",
                table: "RolePermissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions",
                schema: "System");

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0125afe0-195b-4aae-8003-d12f69495840"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("03658210-23cc-44e6-9b77-1d56e6cb6a9b"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7bc3bd23-379b-4bdf-9367-b0e05afaf50f"));

            migrationBuilder.CreateTable(
                name: "AccountPermissions",
                schema: "System",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedById = table.Column<Guid>(nullable: true),
                    PermissionName = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountPermissions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "System",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("37a9acb7-340a-4a5e-ba98-14633ea504a7"), "SuperAdmin", new DateTime(2019, 2, 25, 10, 20, 7, 605, DateTimeKind.Local).AddTicks(1472), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("25a0ded5-e752-4bbe-acde-c3978272d74d"), "Admin", new DateTime(2019, 2, 25, 10, 20, 7, 606, DateTimeKind.Local).AddTicks(7894), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("67f066c6-e884-46f8-8a1d-4e009171d878"), "User", new DateTime(2019, 2, 25, 10, 20, 7, 606, DateTimeKind.Local).AddTicks(7906), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPermissions_AccountId",
                schema: "System",
                table: "AccountPermissions",
                column: "AccountId");
        }
    }
}
