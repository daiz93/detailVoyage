using DossierAPI.DTOs;

namespace DossierAPI.Services
{
    public interface ITypeVoyageService
    {
        public bool IdExist(int ID);
        public bool TypeVoyageExist(NewTypeVoyageDTO TypeVoyage);
        public Task<List<TypeVoyageDTO>> GetTypeVoyages();
        public Task<TypeVoyageDTO> GetTypeVoyage(int ID);

        public Task<TypeVoyageDTO?> AddTypeVoyage(NewTypeVoyageDTO newTypeVoyageDTO);

        public Task<TypeVoyageDTO> UpdateTypeVoyage(TypeVoyageDTO TypeVoyage);
        public Task<List<TypeVoyageDTO>> DeleteTypeVoyage(int ID);
    }
}
