using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AnexoUnoParteUnoCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antecedentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionPrograma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContextoHistoricoNormativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblematicaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciasPrevias = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecedentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coberturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificacionCaracterizacionPoblacionPotencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificacionCaracterizacionPoblacionObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuantificacionPoblaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuantificacionPoblacionPotencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuantificacionPoblacionObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuantificacionPoblacionAtendidaAnterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaActualizacionPoblacionPotencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaActualizacionPoblacionObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcesoIdentificacionPoblacionPotencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcesoIdentificacionPoblacionObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coberturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeterminacionJustificacionObjetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjetivosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelacionOtrosProgramas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeterminacionJustificacionObjetivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisenoIntervencionPublicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Componentes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtapasIntervencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscenariosFuturosEsperar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisenoIntervencionPublicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificacionDescripcionProblemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemaCentral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Involucrados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Causas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evolucion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificacionDescripcionProblemas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antecedentes");

            migrationBuilder.DropTable(
                name: "Coberturas");

            migrationBuilder.DropTable(
                name: "DeterminacionJustificacionObjetivo");

            migrationBuilder.DropTable(
                name: "DisenoIntervencionPublicas");

            migrationBuilder.DropTable(
                name: "IdentificacionDescripcionProblemas");
        }
    }
}
