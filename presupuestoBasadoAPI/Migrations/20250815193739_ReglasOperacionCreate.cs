using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReglasOperacionCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PadronBeneficiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TienePadron = table.Column<bool>(type: "bit", nullable: false),
                    ArchivoAdjunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LigaInternet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadronBeneficiarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReglasOperacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieneReglasOperacion = table.Column<bool>(type: "bit", nullable: false),
                    ArchivoAdjunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LigaInternet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglasOperacion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PadronBeneficiarios");

            migrationBuilder.DropTable(
                name: "ReglasOperacion");
        }
    }
}
