using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class ComponenteModalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Programas_ProgramaPresupuestarioId",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "Componentes",
                table: "DisenoIntervencionPublicas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Componentes");

            migrationBuilder.RenameColumn(
                name: "ProgramaPresupuestarioId",
                table: "Componentes",
                newName: "DisenoIntervencionPublicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Componentes_ProgramaPresupuestarioId",
                table: "Componentes",
                newName: "IX_Componentes_DisenoIntervencionPublicaId");

            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acciones_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_ComponenteId",
                table: "Acciones",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_ComponenteId",
                table: "Resultados",
                column: "ComponenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_DisenoIntervencionPublicas_DisenoIntervencionPublicaId",
                table: "Componentes",
                column: "DisenoIntervencionPublicaId",
                principalTable: "DisenoIntervencionPublicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_DisenoIntervencionPublicas_DisenoIntervencionPublicaId",
                table: "Componentes");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.RenameColumn(
                name: "DisenoIntervencionPublicaId",
                table: "Componentes",
                newName: "ProgramaPresupuestarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Componentes_DisenoIntervencionPublicaId",
                table: "Componentes",
                newName: "IX_Componentes_ProgramaPresupuestarioId");

            migrationBuilder.AddColumn<string>(
                name: "Componentes",
                table: "DisenoIntervencionPublicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Componentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Programas_ProgramaPresupuestarioId",
                table: "Componentes",
                column: "ProgramaPresupuestarioId",
                principalTable: "Programas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
