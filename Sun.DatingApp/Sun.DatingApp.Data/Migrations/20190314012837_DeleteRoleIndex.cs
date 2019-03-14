using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class DeleteRoleIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleId",
                schema: "system",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_RoleId",
                schema: "system",
                table: "Account");

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9078200c-2457-4c41-a564-b509cf032da7"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("92868a6f-f944-43df-9f10-d7773456471e"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("da9303d9-bed4-472d-85c3-988bdf0a5730"));

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("9510fcf8-cd30-4680-91d7-c97689f8d287"), false, new DateTime(2019, 3, 14, 9, 28, 36, 850, DateTimeKind.Local).AddTicks(1926), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("e73d8306-4013-4049-8a71-54683d726e47"), false, new DateTime(2019, 3, 14, 9, 28, 36, 851, DateTimeKind.Local).AddTicks(1845), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("f6a17c7b-4812-43f9-91a3-e2fc161209af"), false, new DateTime(2019, 3, 14, 9, 28, 36, 851, DateTimeKind.Local).AddTicks(1853), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9510fcf8-cd30-4680-91d7-c97689f8d287"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e73d8306-4013-4049-8a71-54683d726e47"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f6a17c7b-4812-43f9-91a3-e2fc161209af"));

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("da9303d9-bed4-472d-85c3-988bdf0a5730"), false, new DateTime(2019, 3, 13, 21, 9, 51, 710, DateTimeKind.Local).AddTicks(994), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("92868a6f-f944-43df-9f10-d7773456471e"), false, new DateTime(2019, 3, 13, 21, 9, 51, 711, DateTimeKind.Local).AddTicks(1160), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("9078200c-2457-4c41-a564-b509cf032da7"), false, new DateTime(2019, 3, 13, 21, 9, 51, 711, DateTimeKind.Local).AddTicks(1171), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                schema: "system",
                table: "Account",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleId",
                schema: "system",
                table: "Account",
                column: "RoleId",
                principalSchema: "system",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
