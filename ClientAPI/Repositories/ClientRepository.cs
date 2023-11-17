using ClientAPI.Data;
using ClientAPI.IRepositories;
using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContext _dbContext;

        public ClientRepository(ClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Client?> Add(Client Client)
        {
           var clientAdded = _dbContext.Clients.Add(Client).Entity;
            await _dbContext.SaveChangesAsync();
            return clientAdded;
        }

        public async Task<List<Client>> DeleteAsync(int ClientId)
        {
            var client = await _dbContext.Clients.FindAsync(ClientId);
            if (client != null)
            {
                client.Actif = false;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Clients.Where(client => client.Actif).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _dbContext.Clients.Where(client => client.Actif).ToListAsync();
        }

        public async Task<Client?> GetById(int ClientId)
        {
            return await _dbContext.Clients.FindAsync(ClientId);
        }

        public async Task<List<Client>> RestoreAsync(int ClientId)
        {
            var client = await _dbContext.Clients.FindAsync(ClientId);
            if (client != null)
            {
                client.Actif = true;
                await _dbContext.SaveChangesAsync();
            }

            return await _dbContext.Clients.Where(client => client.Actif).ToListAsync();
        }

        public async Task<Client?> UpdateAsync(Client Client)
        {
             _dbContext.Entry(Client).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return Client;
        }
    }
}
