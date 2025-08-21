using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace presupuestoBasadoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnaRamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlineacionesEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acuerdo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrategia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineaAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ramo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlineacionesEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlineacionesMunicipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acuerdo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrategia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineaAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ramo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlineacionesMunicipio", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlineacionesEstado");

            migrationBuilder.DropTable(
                name: "AlineacionesMunicipio");

        }
    }
}
