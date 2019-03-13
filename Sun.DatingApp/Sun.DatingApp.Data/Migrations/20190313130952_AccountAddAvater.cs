using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class AccountAddAvater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3711b967-cfb8-4e48-9db6-551ad2d48a31"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6d494fed-e660-42ce-89c5-27699e2dadcd"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("917cfe90-a330-4a06-a3ba-577fe4418568"));

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                schema: "system",
                table: "Account",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Avatar",
                schema: "system",
                table: "Account");

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
        }
    }
}
