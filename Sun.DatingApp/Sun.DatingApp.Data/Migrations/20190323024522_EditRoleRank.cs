using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditRoleRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemPermission_SystemPage_PageId",
                table: "SystemPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemRolePermission_SystemRole_RoleId",
                table: "SystemRolePermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemRolePermission_RoleId",
                table: "SystemRolePermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemPermission_PageId",
                table: "SystemPermission");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "SystemRole",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "SystemPermission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SystemPage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SystemMenu",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "SystemRole");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "SystemPermission");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "SystemPage");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "SystemMenu");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolePermission_RoleId",
                table: "SystemRolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_PageId",
                table: "SystemPermission",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemPermission_SystemPage_PageId",
                table: "SystemPermission",
                column: "PageId",
                principalTable: "SystemPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemRolePermission_SystemRole_RoleId",
                table: "SystemRolePermission",
                column: "RoleId",
                principalTable: "SystemRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
