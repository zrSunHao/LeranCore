using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sun.DatingApp.Data.Migrations
{
    public partial class AddSettingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 500, nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedById = table.Column<Guid>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(maxLength: 150, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSetting");
        }
    }
}
