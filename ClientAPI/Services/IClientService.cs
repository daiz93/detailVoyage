using ClientAPI.DTOs;

namespace ClientAPI.Services
{
    public interface IClientService
    {
        public bool IdExist(int ID);
        public bool ClientExist(NewClientDTO Client);
        public  Task<List<ClientDTO>> GetClients();
        public Task<ClientDTO> GetClient(int ID);

        public Task<ClientDTO?> AddClient(NewClientDTO Client);

        public Task<ClientDTO> UpdateClient(ClientDTO Client);
        public Task<List<ClientDTO>> DeleteClient(int ID);


    }
}
