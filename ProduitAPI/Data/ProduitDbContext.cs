using ProduitAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace ProduitAPI.Data
{
    public class ProduitDbContext : DbContext
    {
        public ProduitDbContext(DbContextOptions<ProduitDbContext> Options) : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
