using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class addPermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c9bdc97-7ce6-4dec-b36c-389aa0af833a"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("94dff301-1b9b-4aee-8eed-6234971ffb22"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e4a3e914-4d02-4d25-805c-024e785f7095"));

            migrationBuilder.CreateTable(
                name: "AccountPermissions",
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
                    PermissionName = table.Column<string>(maxLength: 100, nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("94dff301-1b9b-4aee-8eed-6234971ffb22"), "SuperAdmin", new DateTime(2019, 1, 12, 13, 33, 56, 16, DateTimeKind.Local).AddTicks(6773), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("4c9bdc97-7ce6-4dec-b36c-389aa0af833a"), "Admin", new DateTime(2019, 1, 12, 13, 33, 56, 18, DateTimeKind.Local).AddTicks(182), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("e4a3e914-4d02-4d25-805c-024e785f7095"), "User", new DateTime(2019, 1, 12, 13, 33, 56, 18, DateTimeKind.Local).AddTicks(190), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
