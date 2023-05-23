using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LumiaMvc.Migrations
{
    public partial class addwrk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Work",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Work",
                table: "Teams");
        }
    }
}
