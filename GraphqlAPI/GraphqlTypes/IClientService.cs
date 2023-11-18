using ClientAPI.Models;

public interface IClientService
{

    public Task<List<Client>> ClientListAsync();

    public Task<bool> AddClientAsync(Client clent);

    public Task<bool> UpdateClientAsync(Client clent);

    public Task<bool> DeleteClientAsync(Guid productId);
}