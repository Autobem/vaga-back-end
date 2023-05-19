using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleRegistry.Migrations.Business
{
    /// <inheritdoc />
    public partial class Business : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFuels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_VehicleTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    FuelId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plate = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleFuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "VehicleFuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("150e62cc-84be-4c98-9570-1b037e69d8d5"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Nissan", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("3cb22682-044c-4747-a1d8-8e8cf0982748"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Fiat", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("4af78d17-cc18-4144-99dc-4c8f0e8d002f"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Hyundai", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("549b5854-8885-4c66-8322-0a3c7fa0f373"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "GM", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("5b98e776-7b5e-42e5-aeac-7f591995ea75"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Peugeot", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("68d4d7ee-2842-41c4-97bc-952bb53b5fd9"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Ford", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("a26b77fc-336c-41a3-8b67-d8579811f115"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Toyota", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("a4525922-664f-413f-b068-b7a118dc566d"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Chevrolet", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("a80ad2f9-b50b-476a-842d-b12564f50011"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Honda", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("b4dfad56-bb52-41e2-aa8a-fa05e1b27ccf"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Jeep", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("d69785ce-4841-4ff6-be11-584b1b82e71d"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Volkswagen", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("e62be930-b819-49b4-901e-0a94b300cd91"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840), "Renault", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5840) }
                });

            migrationBuilder.InsertData(
                table: "VehicleColors",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0550da29-8022-4cb2-8de3-c4f503beab6d"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Branco", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("4d0ec66c-da8b-418c-9f8e-6b6c11ed4140"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Preto", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("74bf9c8a-262b-4325-aefc-1834f6e77192"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Cinza", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("93e8104c-4ce7-40ce-b9e3-c988204ea615"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Verde", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("a4745231-46ba-4a53-b6b6-ac329d1ef1a3"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Azul", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("c5eb6535-d793-4999-a398-aac479d6cea3"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400), "Vermelho", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5400) }
                });

            migrationBuilder.InsertData(
                table: "VehicleFuels",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c15413b-05e4-4f61-80f7-09258edd9eea"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Flex", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("19356992-5b66-4acf-9a81-6b157be60108"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Gás", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("22eb4bbe-ceba-435a-a554-15e8a2164a61"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Diesel", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("ac936171-8484-4a8d-b736-a8a065f3af04"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Álcool", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("cf8bfe79-67e2-41b6-92e8-944a520fc2bd"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Nenhum", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("f6d65bc8-d211-440c-b5d5-a384cc20a3e5"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720), "Gasolina", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5720) }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("21f23f60-c1b8-43ab-a20a-c8a50669ef25"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Furgão", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("282d343c-5521-4f1e-9aab-b33c00dcbc5e"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Esportivo", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("6091d04f-7ccd-496a-9189-90fbf0bc0f95"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Sedã", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("650d9e17-2033-43a9-b20c-7ddacddbb691"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Perua", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("93f155e5-7588-4780-8da8-e873dc8e791c"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Picape", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("b46925bf-e18d-41ab-98b9-e8c74fffefe7"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Crossover", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("c3100d62-cbfb-4a3c-9d91-db5ee71acb11"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Hatch", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("e35fe407-5852-4bed-a932-4717a373cf6b"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "SUV", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("f85df1e9-9f24-460c-9d45-18cd3d60e7d5"), new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770), "Minivan", new DateTime(2023, 5, 19, 5, 38, 47, 513, DateTimeKind.Utc).AddTicks(5770) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_TypeId",
                table: "Models",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelId",
                table: "Vehicles",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OwnerId",
                table: "Vehicles",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "VehicleColors");

            migrationBuilder.DropTable(
                name: "VehicleFuels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
