using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class RestructurePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("317d7376-5a9f-487a-92ab-9b470168a91b"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bd377ff4-0420-4256-9207-ba90a371a272"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("edee40d5-f4af-4214-a6b1-26a7493e2ed4"));

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "System",
                table: "Page");

            migrationBuilder.AddColumn<Guid>(
                name: "PageId",
                schema: "System",
                table: "RolePermissions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PageId",
                schema: "System",
                table: "Permissions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("48d3d1c7-8471-4741-aabd-0c7fd9dedae0"), false, "SuperAdmin", new DateTime(2019, 3, 12, 22, 49, 0, 279, DateTimeKind.Local).AddTicks(1057), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("d867b111-a7e6-47f4-ae03-87e3e3846928"), false, "Admin", new DateTime(2019, 3, 12, 22, 49, 0, 281, DateTimeKind.Local).AddTicks(1), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("849f2cf8-3106-49f9-a23a-0cb68cbc7804"), false, "User", new DateTime(2019, 3, 12, 22, 49, 0, 281, DateTimeKind.Local).AddTicks(18), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PageId",
                schema: "System",
                table: "Permissions",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Page_PageId",
                schema: "System",
                table: "Permissions",
                column: "PageId",
                principalSchema: "System",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Page_PageId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PageId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("48d3d1c7-8471-4741-aabd-0c7fd9dedae0"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("849f2cf8-3106-49f9-a23a-0cb68cbc7804"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d867b111-a7e6-47f4-ae03-87e3e3846928"));

            migrationBuilder.DropColumn(
                name: "PageId",
                schema: "System",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "PageId",
                schema: "System",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "System",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModuleId",
                schema: "System",
                table: "Page",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("bd377ff4-0420-4256-9207-ba90a371a272"), false, "SuperAdmin", new DateTime(2019, 3, 12, 14, 23, 58, 516, DateTimeKind.Local).AddTicks(4956), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("edee40d5-f4af-4214-a6b1-26a7493e2ed4"), false, "Admin", new DateTime(2019, 3, 12, 14, 23, 58, 517, DateTimeKind.Local).AddTicks(4545), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("317d7376-5a9f-487a-92ab-9b470168a91b"), false, "User", new DateTime(2019, 3, 12, 14, 23, 58, 517, DateTimeKind.Local).AddTicks(4552), null, false, null, null, "可以使用基本功能", "用户", null, null });

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
    }
}
