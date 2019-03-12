using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class AddRolePageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8a2730f4-3a11-4763-8caf-05ed0f31e4ee"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("af94bdf9-92b9-4183-a1d6-699cfe2bed9c"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4182f80-76d7-4b13-8b06-e1d2d14d3c45"));

            migrationBuilder.DropColumn(
                name: "IsModule",
                schema: "System",
                table: "RolePermissions");

            migrationBuilder.EnsureSchema(
                name: "RolePermissions");

            migrationBuilder.CreateTable(
                name: "RolePage",
                schema: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    PageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePage_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "System",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("d6f0ba97-8b31-4612-8779-47a083ed965e"), false, "SuperAdmin", new DateTime(2019, 3, 12, 13, 29, 16, 834, DateTimeKind.Local).AddTicks(4204), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("6b7ab2e5-e1c9-4702-8921-9906191dcd82"), false, "Admin", new DateTime(2019, 3, 12, 13, 29, 16, 835, DateTimeKind.Local).AddTicks(2458), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("0741ff76-5117-49ac-a87f-e814a4592033"), false, "User", new DateTime(2019, 3, 12, 13, 29, 16, 835, DateTimeKind.Local).AddTicks(2464), null, false, null, null, "可以使用基本功能", "用户", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RolePage_RoleId",
                schema: "RolePermissions",
                table: "RolePage",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePage",
                schema: "RolePermissions");

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0741ff76-5117-49ac-a87f-e814a4592033"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b7ab2e5-e1c9-4702-8921-9906191dcd82"));

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6f0ba97-8b31-4612-8779-47a083ed965e"));

            migrationBuilder.AddColumn<string>(
                name: "IsModule",
                schema: "System",
                table: "RolePermissions",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("b4182f80-76d7-4b13-8b06-e1d2d14d3c45"), false, "SuperAdmin", new DateTime(2019, 3, 7, 14, 19, 17, 401, DateTimeKind.Local).AddTicks(9455), null, false, null, null, "超级管理员拥有所有的权限", "超级管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("8a2730f4-3a11-4763-8caf-05ed0f31e4ee"), false, "Admin", new DateTime(2019, 3, 7, 14, 19, 17, 407, DateTimeKind.Local).AddTicks(1714), null, false, null, null, "管理员用于管理用户权限", "管理员", null, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Intro", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("af94bdf9-92b9-4183-a1d6-699cfe2bed9c"), false, "User", new DateTime(2019, 3, 7, 14, 19, 17, 407, DateTimeKind.Local).AddTicks(1728), null, false, null, null, "可以使用基本功能", "用户", null, null });
        }
    }
}
