using DossierAPI.Models;

namespace DossierAPI.IRepositories
{
    public interface ITypeVoyageRepository
    {
        Task<TypeVoyage?> GetById(int TypeVoyageId);
        Task<IEnumerable<TypeVoyage>> GetAllAsync();
        Task<TypeVoyage?> Add(TypeVoyage TypeVoyage);
        Task<TypeVoyage?> UpdateAsync(TypeVoyage TypeVoyage);
        Task<List<TypeVoyage>> DeleteAsync(int TypeVoyageId);
        Task<List<TypeVoyage>> RestoreAsync(int TypeVoyageId);
    }
}
