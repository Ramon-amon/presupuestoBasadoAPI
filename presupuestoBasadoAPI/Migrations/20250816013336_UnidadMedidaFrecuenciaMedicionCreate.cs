using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UnidadMedidaFrecuenciaMedicionCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuantificacionPoblaciones",
                table: "Coberturas");

            migrationBuilder.RenameColumn(
                name: "FrecuenciaActualizacionPoblacionPotencial",
                table: "Coberturas",
                newName: "UnidadMedida");

            migrationBuilder.RenameColumn(
                name: "FrecuenciaActualizacionPoblacionObjetivo",
                table: "Coberturas",
                newName: "FrecuenciaActualizacion");

            migrationBuilder.AlterColumn<int>(
                name: "CuantificacionPoblacionPotencial",
                table: "Coberturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CuantificacionPoblacionObjetivo",
                table: "Coberturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CuantificacionPoblacionAtendidaAnterior",
                table: "Coberturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnidadMedida",
                table: "Coberturas",
                newName: "FrecuenciaActualizacionPoblacionPotencial");

            migrationBuilder.RenameColumn(
                name: "FrecuenciaActualizacion",
                table: "Coberturas",
                newName: "FrecuenciaActualizacionPoblacionObjetivo");

            migrationBuilder.AlterColumn<string>(
                name: "CuantificacionPoblacionPotencial",
                table: "Coberturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CuantificacionPoblacionObjetivo",
                table: "Coberturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CuantificacionPoblacionAtendidaAnterior",
                table: "Coberturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CuantificacionPoblaciones",
                table: "Coberturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
