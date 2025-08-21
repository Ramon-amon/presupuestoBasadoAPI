using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CausasDivididasCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Causas",
                table: "IdentificacionDescripcionProblemas",
                newName: "CausaOpositores");

            migrationBuilder.AddColumn<string>(
                name: "CausaBeneficiados",
                table: "IdentificacionDescripcionProblemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CausaEjecutores",
                table: "IdentificacionDescripcionProblemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CausaIndiferentes",
                table: "IdentificacionDescripcionProblemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CausaBeneficiados",
                table: "IdentificacionDescripcionProblemas");

            migrationBuilder.DropColumn(
                name: "CausaEjecutores",
                table: "IdentificacionDescripcionProblemas");

            migrationBuilder.DropColumn(
                name: "CausaIndiferentes",
                table: "IdentificacionDescripcionProblemas");

            migrationBuilder.RenameColumn(
                name: "CausaOpositores",
                table: "IdentificacionDescripcionProblemas",
                newName: "Causas");
        }
    }
}
