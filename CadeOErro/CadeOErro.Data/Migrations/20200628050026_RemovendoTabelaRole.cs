using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeOErro.Data.Migrations
{
    public partial class RemovendoTabelaRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_id_role",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_User_id_role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "id_role",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "User",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "id_role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_id_role",
                table: "User",
                column: "id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_id_role",
                table: "User",
                column: "id_role",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
