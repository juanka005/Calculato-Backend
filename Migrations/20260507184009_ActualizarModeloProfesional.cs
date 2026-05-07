using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculato.Api.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloProfesional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Monto",
                table: "Transacciones",
                newName: "TotalPagado");

            migrationBuilder.AddColumn<bool>(
                name: "EstaAnulada",
                table: "Transacciones",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Ganancia",
                table: "Transacciones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ItbisPagado",
                table: "Transacciones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Transacciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotivoAnulacion",
                table: "Transacciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ncf",
                table: "Transacciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Transacciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RncCliente",
                table: "Transacciones",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaAnulada",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Ganancia",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "ItbisPagado",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "MotivoAnulacion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Ncf",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "RncCliente",
                table: "Transacciones");

            migrationBuilder.RenameColumn(
                name: "TotalPagado",
                table: "Transacciones",
                newName: "Monto");
        }
    }
}
