using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class UpdateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "System",
                table: "Roles",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "System",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleCode",
                schema: "System",
                table: "Accounts");
        }
    }
}
