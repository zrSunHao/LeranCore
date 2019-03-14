using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "system",
                table: "Account",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "system",
                table: "Account");

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
    }
}
