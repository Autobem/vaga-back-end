using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.API.Data.Migrations
{
    public partial class alter_owner_cpfcnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb054ec5-ba1b-4c62-b71b-0dccfa4777f9"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfCnpj",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("f222a951-9c1e-41cb-b3d8-062b43b2493b"), new DateTime(2021, 6, 21, 19, 10, 4, 36, DateTimeKind.Utc).AddTicks(4859), "admin@admin.com", "Administrador", "12345678", new DateTime(2021, 6, 21, 19, 10, 4, 36, DateTimeKind.Utc).AddTicks(6036) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f222a951-9c1e-41cb-b3d8-062b43b2493b"));

            migrationBuilder.DropColumn(
                name: "CpfCnpj",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("fb054ec5-ba1b-4c62-b71b-0dccfa4777f9"), new DateTime(2021, 6, 17, 20, 15, 18, 97, DateTimeKind.Utc).AddTicks(7248), "admin@admin.com", "Administrador", "12345678", new DateTime(2021, 6, 17, 20, 15, 18, 97, DateTimeKind.Utc).AddTicks(8392) });
        }
    }
}
