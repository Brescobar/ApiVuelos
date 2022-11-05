using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenVuelos.Migrations
{
    public partial class INIT1590194567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    IdAvion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.IdAvion);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    IdDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDestino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.IdDestino);
                });

            migrationBuilder.CreateTable(
                name: "Piloto",
                columns: table => new
                {
                    IdPiloto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piloto", x => x.IdPiloto);
                });

            migrationBuilder.CreateTable(
                name: "Voleto",
                columns: table => new
                {
                    IdVoleto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePasajero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tarifa = table.Column<double>(type: "float", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voleto", x => x.IdVoleto);
                    table.ForeignKey(
                        name: "FK_Voleto_Destino_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
                        principalColumn: "IdDestino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    IdVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaFechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaFechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    PilotoId = table.Column<int>(type: "int", nullable: false),
                    AvionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.IdVuelo);
                    table.ForeignKey(
                        name: "FK_Vuelo_Avion_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Avion",
                        principalColumn: "IdAvion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelo_Destino_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
                        principalColumn: "IdDestino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelo_Piloto_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Piloto",
                        principalColumn: "IdPiloto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voleto_DestinoId",
                table: "Voleto",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_AvionId",
                table: "Vuelo",
                column: "AvionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_DestinoId",
                table: "Vuelo",
                column: "DestinoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_PilotoId",
                table: "Vuelo",
                column: "PilotoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voleto");

            migrationBuilder.DropTable(
                name: "Vuelo");

            migrationBuilder.DropTable(
                name: "Avion");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Piloto");
        }
    }
}
