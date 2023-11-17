using ClientAPI.Models;
using DossierAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProduitAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class TDbContext: DbContext
    {
        public TDbContext(DbContextOptions<TDbContext> Options) : base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<TypeVoyage> TypeVoyages { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
