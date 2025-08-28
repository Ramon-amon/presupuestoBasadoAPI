using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArbolObjetivosCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArbolObjetivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjetivoCentral = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbolObjetivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteObjetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArbolObjetivosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteObjetivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponenteObjetivo_ArbolObjetivos_ArbolObjetivosId",
                        column: x => x.ArbolObjetivosId,
                        principalTable: "ArbolObjetivos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteObjetivo_ArbolObjetivosId",
                table: "ComponenteObjetivo",
                column: "ArbolObjetivosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteObjetivo");

            migrationBuilder.DropTable(
                name: "ArbolObjetivos");
        }
    }
}
