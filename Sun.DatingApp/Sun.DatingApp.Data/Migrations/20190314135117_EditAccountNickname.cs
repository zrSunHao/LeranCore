using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditAccountNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "system",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                schema: "system",
                table: "Account",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("8ea3381a-8dfe-4160-ab58-1f6a91720791"), false, new DateTime(2019, 3, 14, 21, 51, 17, 344, DateTimeKind.Local).AddTicks(5451), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("81d01448-7098-4443-9d2a-cdfe5ed257c9"), false, new DateTime(2019, 3, 14, 21, 51, 17, 345, DateTimeKind.Local).AddTicks(5298), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "system",
                table: "Role",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("dcad6818-7bbd-4eef-8260-1cb3ee52d71c"), false, new DateTime(2019, 3, 14, 21, 51, 17, 345, DateTimeKind.Local).AddTicks(5310), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("81d01448-7098-4443-9d2a-cdfe5ed257c9"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8ea3381a-8dfe-4160-ab58-1f6a91720791"));

            migrationBuilder.DeleteData(
                schema: "system",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("dcad6818-7bbd-4eef-8260-1cb3ee52d71c"));

            migrationBuilder.DropColumn(
                name: "Nickname",
                schema: "system",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "system",
                table: "Account",
                maxLength: 50,
                nullable: true);

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
    }
}
