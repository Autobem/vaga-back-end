using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeVeiculos.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "varchar(80)", nullable: true),
                    Lastname = table.Column<string>(type: "varchar(80)", nullable: true),
                    Client_Phone = table.Column<string>(type: "varchar(11)", nullable: false),
                    Client_Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Client_Document = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Login = table.Column<string>(type: "varchar(20)", nullable: false),
                    User_Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    User_Password = table.Column<string>(type: "varchar(12)", nullable: false),
                    User_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_Model = table.Column<string>(type: "varchar(50)", nullable: false),
                    Vehicle_Manufacture = table.Column<string>(type: "varchar(70)", nullable: false),
                    Vehicle_Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Vehicle_Plate = table.Column<string>(type: "varchar(7)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Client_Document",
                table: "Clients",
                column: "Client_Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Login",
                table: "Users",
                column: "User_Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicles",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
