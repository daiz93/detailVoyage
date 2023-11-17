using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DossierAPI.Migrations
{
    /// <inheritdoc />
    public partial class DossierModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    DossierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeVoyageId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateArrivee = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DureeSejourJours = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroVol = table.Column<string>(type: "TEXT", nullable: false),
                    Lieu = table.Column<string>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.DossierId);
                });

            migrationBuilder.CreateTable(
                name: "TypeVoyages",
                columns: table => new
                {
                    TypeVoyageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVoyages", x => x.TypeVoyageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "TypeVoyages");
        }
    }
}
