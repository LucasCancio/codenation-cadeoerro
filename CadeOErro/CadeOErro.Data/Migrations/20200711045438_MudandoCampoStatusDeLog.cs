using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeOErro.Data.Migrations
{
    public partial class MudandoCampoStatusDeLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Log");

            migrationBuilder.AddColumn<bool>(
                name: "filed",
                table: "Log",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filed",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
