using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeOErro.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LogLevel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    cpf = table.Column<string>(nullable: false),
                    token = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    id_role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Role_id_role",
                        column: x => x.id_role,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    frequency = table.Column<int>(nullable: false),
                    source = table.Column<string>(nullable: false),
                    stackTrace = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    filed_date = table.Column<DateTime>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    id_user = table.Column<int>(nullable: false),
                    id_environment = table.Column<int>(nullable: false),
                    id_log_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.id);
                    table.ForeignKey(
                        name: "FK_Log_Environment_id_environment",
                        column: x => x.id_environment,
                        principalTable: "Environment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_LogLevel_id_log_level",
                        column: x => x.id_log_level,
                        principalTable: "LogLevel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_id_environment",
                table: "Log",
                column: "id_environment");

            migrationBuilder.CreateIndex(
                name: "IX_Log_id_log_level",
                table: "Log",
                column: "id_log_level");

            migrationBuilder.CreateIndex(
                name: "IX_Log_id_user",
                table: "Log",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_role",
                table: "User",
                column: "id_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Environment");

            migrationBuilder.DropTable(
                name: "LogLevel");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
