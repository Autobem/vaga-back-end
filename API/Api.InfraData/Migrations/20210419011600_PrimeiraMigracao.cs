using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    atualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    documento = table.Column<string>(unicode: false, maxLength: 14, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    cidade = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    uf = table.Column<string>(unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    criacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    atualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    modelo = table.Column<short>(nullable: false),
                    ano = table.Column<short>(nullable: false),
                    placa = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    portas = table.Column<byte>(nullable: true),
                    km = table.Column<int>(nullable: true),
                    cambio = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    pessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Pessoa",
                        column: x => x.pessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ID01_Pessoa",
                table: "Pessoas",
                column: "documento");

            migrationBuilder.CreateIndex(
                name: "ID01_Veiculo",
                table: "Veiculos",
                column: "ano");

            migrationBuilder.CreateIndex(
                name: "ID03_Veiculo",
                table: "Veiculos",
                column: "modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_pessoaId",
                table: "Veiculos",
                column: "pessoaId");

            migrationBuilder.CreateIndex(
                name: "ID02_Veiculo",
                table: "Veiculos",
                column: "placa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
