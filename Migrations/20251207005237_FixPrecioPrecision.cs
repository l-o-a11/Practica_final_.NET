using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFinal.Migrations
{
    /// <inheritdoc />
    public partial class FixPrecioPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DT = table.Column<long>(type: "bigint", nullable: false),
                    Document = table.Column<long>(type: "bigint", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsapp = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clientes_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ReservationsId",
                table: "Clientes",
                column: "ReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdClient",
                table: "Reservations",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdService",
                table: "Reservations",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ReservationsId",
                table: "Servicios",
                column: "ReservationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Reservations_ReservationsId",
                table: "Clientes",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Servicios_IdService",
                table: "Reservations",
                column: "IdService",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Reservations_ReservationsId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Reservations_ReservationsId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
