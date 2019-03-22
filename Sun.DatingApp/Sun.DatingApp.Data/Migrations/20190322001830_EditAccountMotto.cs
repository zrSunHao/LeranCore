using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class EditAccountMotto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "SystemUserInfo");

            migrationBuilder.AddColumn<string>(
                name: "Motto",
                table: "SystemUserInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motto",
                table: "SystemUserInfo");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                table: "SystemUserInfo",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
