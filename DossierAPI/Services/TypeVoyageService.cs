using DossierAPI.DTOs;
using DossierAPI.IRepositories;
using DossierAPI.Models;

namespace DossierAPI.Services
{
    public class TypeVoyageService : ITypeVoyageService
    {

        private readonly ITypeVoyageRepository _typeVoyageRepository;
        public TypeVoyageService(ITypeVoyageRepository typeVoyageRepository)
        {
            _typeVoyageRepository = typeVoyageRepository;
        }


        public async Task<TypeVoyageDTO?> AddTypeVoyage(NewTypeVoyageDTO typeVoyage)
        {
            if (typeVoyage == null) throw new ArgumentNullException(nameof(typeVoyage), "Aucune donnée à enregistrer");

            if (TypeVoyageExist(typeVoyage)) throw new ArgumentException("Le client existe déjà.");

            var newTypeVoyage = new TypeVoyage
            {
                
               Libelle = typeVoyage.Libelle,
                Actif = typeVoyage.Actif
            };

            var addedTypeVoyage = await _typeVoyageRepository.Add(newTypeVoyage);
            return addedTypeVoyage != null ? new TypeVoyageDTO()
            {
                TypeVoyageId = addedTypeVoyage.TypeVoyageId,
                Libelle = addedTypeVoyage.Libelle,
                Actif = addedTypeVoyage.Actif
            } : null;

        }

        public Task<List<TypeVoyageDTO>> DeleteTypeVoyage(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<TypeVoyageDTO> GetTypeVoyage(int ID)
        {
            var typeVoyage = await _typeVoyageRepository.GetById(ID);

            TypeVoyageDTO typeVoyageFound = new TypeVoyageDTO();
            if (typeVoyage != null)
            {
                typeVoyageFound = new TypeVoyageDTO()
                {
                    TypeVoyageId = typeVoyage.TypeVoyageId,
                    Libelle = typeVoyage.Libelle,
                  
                    Actif = typeVoyage.Actif

                };
            }

            return typeVoyageFound;
        }

        public async Task<List<TypeVoyageDTO>> GetTypeVoyages()
        {
            List<TypeVoyageDTO> Typevoyages = new List<TypeVoyageDTO>();
            var getTypeVoyages = await _typeVoyageRepository.GetAllAsync();
            if (getTypeVoyages != null)
            {
                foreach (var typeVoyage   in getTypeVoyages)
                {
                    Typevoyages.Add(new TypeVoyageDTO
                    {
                        TypeVoyageId = typeVoyage.TypeVoyageId,
                        Libelle = typeVoyage.Libelle,
                       
                        Actif = typeVoyage.Actif

                    });
                }
            }
            return Typevoyages;

            
        }

        public bool IdExist(int ID)
        {
            var typeVoyage = _typeVoyageRepository.GetById(ID);
            if (typeVoyage == null)
                return false;
            return true;
        }

        public bool TypeVoyageExist(NewTypeVoyageDTO TypeVoyage)
        {
            var TypeVoyageFounded = _typeVoyageRepository.GetAllAsync().Result
                .Any(cli => (cli.Libelle == TypeVoyage.Libelle));


            return TypeVoyageFounded;
        }

        public Task<TypeVoyageDTO> UpdateTypeVoyage(TypeVoyageDTO TypeVoyage)
        {
            throw new NotImplementedException();
        }
    }
}
