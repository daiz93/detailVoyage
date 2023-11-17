using ClientAPI.Models;
using Core.Data;

namespace GraphqlAPI.GraphqlQueries
{
    public class Query
    {
        public IQueryable<Client> GetClients (TDbContext dbContext)
            =>dbContext.Clients;
    }
}
