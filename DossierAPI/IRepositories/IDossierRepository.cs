using DossierAPI.Models;


namespace DossierAPI.IRepositories
{
    public interface IDossierRepository
    {
        Task<Dossier?> GetById(int DossierId);
        Task<IEnumerable<Dossier>> GetAllAsync();
        Task<Dossier?> Add(Dossier Dossier);
        Task<Dossier?> UpdateAsync(Dossier Dossier);
        Task<List<Dossier>> DeleteAsync(int DossierId);
        Task<List<Dossier>> RestoreAsync(int DossierId);

    }
}
