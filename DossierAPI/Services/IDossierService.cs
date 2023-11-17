using DossierAPI.DTOs;

namespace DossierAPI.Services
{
    public interface IDossierService
    {
        public bool IdExist(int ID);
        public bool DossierExist(NewDossierDTO Dossier);
        public  Task<List<DossierDTO>> GetDossiers();
        public Task<DossierDTO> GetDossier(int ID);

        public Task<DossierDTO?> AddDossier(NewDossierDTO Dossier);

        public Task<DossierDTO> UpdateDossier(DossierDTO Dossier);
        public Task<List<DossierDTO>> DeleteDossier(int ID);


    }
}
