using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProduitAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProduitModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fabricant = table.Column<string>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    NombreEtoiles = table.Column<int>(type: "INTEGER", nullable: true),
                    Ville = table.Column<string>(type: "TEXT", nullable: true),
                    Pays = table.Column<string>(type: "TEXT", nullable: true),
                    Adresse = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
