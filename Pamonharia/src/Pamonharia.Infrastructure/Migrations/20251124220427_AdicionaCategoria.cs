using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pamonharia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pamonhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pamonhas_CategoriaId",
                table: "Pamonhas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pamonhas_Categorias_CategoriaId",
                table: "Pamonhas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pamonhas_Categorias_CategoriaId",
                table: "Pamonhas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Pamonhas_CategoriaId",
                table: "Pamonhas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pamonhas");
        }
    }
}
