using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAlimentos.Migrations
{
    /// <inheritdoc />
    public partial class CrieiUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UduarioId",
                table: "Refeicoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Refeicoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dieta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refeicoes_UsuarioId",
                table: "Refeicoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicoes_Usuarios_UsuarioId",
                table: "Refeicoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicoes_Usuarios_UsuarioId",
                table: "Refeicoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Refeicoes_UsuarioId",
                table: "Refeicoes");

            migrationBuilder.DropColumn(
                name: "UduarioId",
                table: "Refeicoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Refeicoes");
        }
    }
}
