using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class PermissionAddActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("786d1e42-a3f6-4ddc-b7cb-d83e2a91eb2e"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a7bc72c7-f492-4720-8bb3-74bb835176ba"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c5d3feef-21cd-487f-9ac2-fcecf1071c94"));

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                schema: "System",
                table: "RolePermissions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "System",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PermissionId",
                schema: "System",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "System",
                table: "Permissions");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("c5d3feef-21cd-487f-9ac2-fcecf1071c94"), "SuperAdmin", new DateTime(2019, 3, 3, 14, 28, 48, 278, DateTimeKind.Local).AddTicks(1309), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("786d1e42-a3f6-4ddc-b7cb-d83e2a91eb2e"), "Admin", new DateTime(2019, 3, 3, 14, 28, 48, 279, DateTimeKind.Local).AddTicks(581), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("a7bc72c7-f492-4720-8bb3-74bb835176ba"), "User", new DateTime(2019, 3, 3, 14, 28, 48, 279, DateTimeKind.Local).AddTicks(588), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
