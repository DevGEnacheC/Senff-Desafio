using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelCarros.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AluguelValorAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorAluguel",
                table: "Alugueis",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorAluguel",
                table: "Alugueis");
        }
    }
}
