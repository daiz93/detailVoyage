using ClientAPI.Models;

namespace ClientAPI.IRepositories
{
    public interface IClientRepository
    {
        Task<Client?> GetById(int ClientId);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> Add(Client Client);
        Task<Client?> UpdateAsync(Client Client);
        Task<List<Client>> DeleteAsync(int ClientId);
        Task<List<Client>> RestoreAsync(int ClientId);
       
    }
}
