using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class PermissionAddTagColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("17a4f91a-819f-4f4d-8380-89bd992485bb"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52b7dbf4-7589-4f9a-a176-aab2e6b63b92"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea5a8774-149f-4cbe-9db2-6d1221796a8c"));

            migrationBuilder.AddColumn<string>(
                name: "TagColor",
                schema: "System",
                table: "Permissions",
                maxLength: 50,
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TagColor",
                schema: "System",
                table: "Permissions");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("ea5a8774-149f-4cbe-9db2-6d1221796a8c"), "SuperAdmin", new DateTime(2019, 3, 4, 9, 1, 34, 277, DateTimeKind.Local).AddTicks(7872), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("17a4f91a-819f-4f4d-8380-89bd992485bb"), "Admin", new DateTime(2019, 3, 4, 9, 1, 34, 279, DateTimeKind.Local).AddTicks(7711), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("52b7dbf4-7589-4f9a-a176-aab2e6b63b92"), "User", new DateTime(2019, 3, 4, 9, 1, 34, 279, DateTimeKind.Local).AddTicks(7723), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
