using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditAccountUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1dd9a482-ce20-4007-997b-2e05caf8eeac"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3e448529-e345-4932-8fea-23631be60b46"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e2cda2f7-f825-41eb-96cf-a86817139e1c"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "system",
                table: "Account",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("98c68160-46d1-48cf-b5a1-7bd04f02105c"), false, new DateTime(2019, 3, 14, 21, 29, 48, 362, DateTimeKind.Local).AddTicks(8008), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("838d4a2b-1cb3-445c-b80a-37e65511fe9b"), false, new DateTime(2019, 3, 14, 21, 29, 48, 364, DateTimeKind.Local).AddTicks(5109), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("b1b41ebe-cb4b-4f6e-b83f-8f19e11a50c1"), false, new DateTime(2019, 3, 14, 21, 29, 48, 364, DateTimeKind.Local).AddTicks(5131), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("838d4a2b-1cb3-445c-b80a-37e65511fe9b"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("98c68160-46d1-48cf-b5a1-7bd04f02105c"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b1b41ebe-cb4b-4f6e-b83f-8f19e11a50c1"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "system",
                table: "Account",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("3e448529-e345-4932-8fea-23631be60b46"), false, new DateTime(2019, 3, 14, 20, 20, 44, 80, DateTimeKind.Local).AddTicks(746), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("e2cda2f7-f825-41eb-96cf-a86817139e1c"), false, new DateTime(2019, 3, 14, 20, 20, 44, 81, DateTimeKind.Local).AddTicks(6936), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("1dd9a482-ce20-4007-997b-2e05caf8eeac"), false, new DateTime(2019, 3, 14, 20, 20, 44, 81, DateTimeKind.Local).AddTicks(6987), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
