using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class AccountDeleteRoleCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0741ff76-5117-49ac-a87f-e814a4592033"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b7ab2e5-e1c9-4702-8921-9906191dcd82"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6f0ba97-8b31-4612-8779-47a083ed965e"));

            migrationBuilder.DropColumn(
                name: "RoleCode",
                schema: "System",
                table: "Accounts");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("bd377ff4-0420-4256-9207-ba90a371a272"), false, "SuperAdmin", new DateTime(2019, 3, 12, 14, 23, 58, 516, DateTimeKind.Local).AddTicks(4956), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("edee40d5-f4af-4214-a6b1-26a7493e2ed4"), false, "Admin", new DateTime(2019, 3, 12, 14, 23, 58, 517, DateTimeKind.Local).AddTicks(4545), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("317d7376-5a9f-487a-92ab-9b470168a91b"), false, "User", new DateTime(2019, 3, 12, 14, 23, 58, 517, DateTimeKind.Local).AddTicks(4552), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("317d7376-5a9f-487a-92ab-9b470168a91b"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bd377ff4-0420-4256-9207-ba90a371a272"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("edee40d5-f4af-4214-a6b1-26a7493e2ed4"));

            migrationBuilder.AddColumn<string>(
                name: "RoleCode",
                schema: "System",
                table: "Accounts",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("d6f0ba97-8b31-4612-8779-47a083ed965e"), false, "SuperAdmin", new DateTime(2019, 3, 12, 13, 29, 16, 834, DateTimeKind.Local).AddTicks(4204), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("6b7ab2e5-e1c9-4702-8921-9906191dcd82"), false, "Admin", new DateTime(2019, 3, 12, 13, 29, 16, 835, DateTimeKind.Local).AddTicks(2458), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("0741ff76-5117-49ac-a87f-e814a4592033"), false, "User", new DateTime(2019, 3, 12, 13, 29, 16, 835, DateTimeKind.Local).AddTicks(2464), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
