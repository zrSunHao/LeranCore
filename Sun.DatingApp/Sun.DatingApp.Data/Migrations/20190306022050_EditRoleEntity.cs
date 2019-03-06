using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditRoleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6bc2049c-9435-40c1-8cb4-0d5d27f39ac5"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70740354-4bd4-40cf-8859-f5fc8430225a"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("de9c3a5c-7578-49a4-b6c2-c047b8e1939b"));

            migrationBuilder.DropColumn(
                name: "PermissionName",
                schema: "System",
                table: "RolePermissions");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "System",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsModule",
                schema: "System",
                table: "RolePermissions",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("a8968c88-c80d-42bf-9289-ff5b6c9d4b7f"), false, "SuperAdmin", new DateTime(2019, 3, 6, 10, 20, 50, 558, DateTimeKind.Local).AddTicks(6377), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("c1fecea0-9acd-41e8-9f9b-5f6d3f8d6caa"), false, "Admin", new DateTime(2019, 3, 6, 10, 20, 50, 560, DateTimeKind.Local).AddTicks(3123), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("970a0200-5a7a-4927-a6e5-52bda26e1037"), false, "User", new DateTime(2019, 3, 6, 10, 20, 50, 560, DateTimeKind.Local).AddTicks(3131), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("970a0200-5a7a-4927-a6e5-52bda26e1037"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8968c88-c80d-42bf-9289-ff5b6c9d4b7f"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c1fecea0-9acd-41e8-9f9b-5f6d3f8d6caa"));

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "System",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsModule",
                schema: "System",
                table: "RolePermissions");

            migrationBuilder.AddColumn<string>(
                name: "PermissionName",
                schema: "System",
                table: "RolePermissions",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("6bc2049c-9435-40c1-8cb4-0d5d27f39ac5"), "SuperAdmin", new DateTime(2019, 3, 5, 17, 17, 32, 609, DateTimeKind.Local).AddTicks(4853), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("de9c3a5c-7578-49a4-b6c2-c047b8e1939b"), "Admin", new DateTime(2019, 3, 5, 17, 17, 32, 610, DateTimeKind.Local).AddTicks(4041), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("70740354-4bd4-40cf-8859-f5fc8430225a"), "User", new DateTime(2019, 3, 5, 17, 17, 32, 610, DateTimeKind.Local).AddTicks(4048), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
