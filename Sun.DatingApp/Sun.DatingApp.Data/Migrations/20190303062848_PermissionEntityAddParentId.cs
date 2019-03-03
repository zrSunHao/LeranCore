using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class PermissionEntityAddParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1376a86a-dd43-4df3-b7e1-91d31f815a8d"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5e1ced11-4703-44e5-b23a-4c7aaa96435b"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a5b4dc16-aa7f-4925-8617-176227750cf6"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "System",
                table: "Permissions",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                schema: "System",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                schema: "System",
                table: "Permissions",
                column: "ParentId",
                principalSchema: "System",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParentId",
                schema: "System",
                table: "Permissions");

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

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("a5b4dc16-aa7f-4925-8617-176227750cf6"), "SuperAdmin", new DateTime(2019, 3, 3, 13, 30, 25, 182, DateTimeKind.Local).AddTicks(6994), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("1376a86a-dd43-4df3-b7e1-91d31f815a8d"), "Admin", new DateTime(2019, 3, 3, 13, 30, 25, 183, DateTimeKind.Local).AddTicks(7586), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("5e1ced11-4703-44e5-b23a-4c7aaa96435b"), "User", new DateTime(2019, 3, 3, 13, 30, 25, 183, DateTimeKind.Local).AddTicks(7595), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
