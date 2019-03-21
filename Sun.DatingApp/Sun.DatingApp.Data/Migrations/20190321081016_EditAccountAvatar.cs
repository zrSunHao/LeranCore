using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditAccountAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "SystemUserInfo");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "SystemAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                table: "SystemUserInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "SystemAccount",
                nullable: true);
        }
    }
}
