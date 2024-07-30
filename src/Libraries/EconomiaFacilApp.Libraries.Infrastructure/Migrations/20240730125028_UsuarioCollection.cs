using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomiaFacilApp.Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioComAcessoId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioComAcessoId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_UsuarioComAcessoId",
                table: "Despesas",
                column: "UsuarioComAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioComAcessoId",
                table: "Categorias",
                column: "UsuarioComAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioComAcessoId",
                table: "Categorias",
                column: "UsuarioComAcessoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_AspNetUsers_UsuarioComAcessoId",
                table: "Despesas",
                column: "UsuarioComAcessoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioComAcessoId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_AspNetUsers_UsuarioComAcessoId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_UsuarioComAcessoId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioComAcessoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioComAcessoId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "UsuarioComAcessoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categorias");
        }
    }
}
