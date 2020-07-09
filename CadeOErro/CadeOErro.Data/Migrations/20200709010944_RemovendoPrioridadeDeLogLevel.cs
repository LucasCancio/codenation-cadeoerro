using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeOErro.Data.Migrations
{
    public partial class RemovendoPrioridadeDeLogLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priority",
                table: "LogLevel");

            migrationBuilder.AddColumn<string>(
                name: "short_name",
                table: "Environment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "short_name",
                table: "Environment");

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "LogLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
