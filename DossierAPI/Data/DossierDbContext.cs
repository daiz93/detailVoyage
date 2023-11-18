using DossierAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace DossierAPI.Data
{
    public class DossierDbContext : DbContext
    {
        public DossierDbContext(DbContextOptions<DossierDbContext> Options) : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<TypeVoyage> TypeVoyages { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }

    }
}
