using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Data
{
    public class ClientDbContext: DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> Options) : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Client> Clients { get; set; }

    }
}
