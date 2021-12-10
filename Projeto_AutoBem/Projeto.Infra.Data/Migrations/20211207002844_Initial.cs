using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    IdProprietario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.IdProprietario);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProprietario = table.Column<int>(nullable: false),
                    Renavam = table.Column<string>(maxLength: 15, nullable: false),
                    Placa = table.Column<string>(maxLength: 10, nullable: false),
                    Ano = table.Column<string>(maxLength: 4, nullable: false),
                    Modelo = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.IdVeiculo);
                    table.ForeignKey(
                        name: "FK_Veiculo_Proprietario_IdProprietario",
                        column: x => x.IdProprietario,
                        principalTable: "Proprietario",
                        principalColumn: "IdProprietario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_CPF",
                table: "Proprietario",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_IdProprietario",
                table: "Veiculo",
                column: "IdProprietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
