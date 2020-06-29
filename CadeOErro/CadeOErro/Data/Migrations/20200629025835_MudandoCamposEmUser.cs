using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeOErro.Server.Migrations
{
    public partial class MudandoCamposEmUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "User");

            migrationBuilder.DropColumn(
                name: "token",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "User",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
