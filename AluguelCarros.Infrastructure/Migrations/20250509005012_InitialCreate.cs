using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelCarros.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Disponivel = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarroId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaxaAtraso = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alugueis_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_CarroId",
                table: "Alugueis",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_ClienteId",
                table: "Alugueis",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
