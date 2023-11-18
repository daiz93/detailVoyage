using DossierAPI.DTOs;
using DossierAPI.IRepositories;
using DossierAPI.Models;
using DossierAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace DossierAPI.Services
{
    public class DossierService:IDossierService
    {

        private readonly IDossierRepository  _dossierRepository;
        public DossierService(IDossierRepository dossierRepository) {
            _dossierRepository = dossierRepository;
        }

       

        public bool DossierExist(NewDossierDTO Dossier)
        {
            var DossierFounded = _dossierRepository.GetAllAsync().Result
               .Any(dos => dos.DateArrivee == Dossier.DateArrivee && dos.DureeSejourJours == Dossier.DureeSejourJours);
            return DossierFounded;
        }


        public virtual  async Task<DossierDTO> GetDossier(int ID)
        {
            var dossier = await  _dossierRepository.GetById(ID);

            DossierDTO DossierFound = new DossierDTO();
            if (dossier != null)
            {
                DossierFound = new DossierDTO()
                {
                    DossierId = dossier.DossierId,
                    
                    Actif = dossier.Actif

                };
            }

            return DossierFound;
        }

        public virtual  async Task<List<DossierDTO>> GetDossiers()
        {
            List<DossierDTO> Dossiers = new List<DossierDTO> ();
            var getDossiers = await _dossierRepository.GetAllAsync();
            if (getDossiers != null)
            {
                foreach (var dossier in getDossiers)
                {
                    Dossiers.Add(new DossierDTO
                    {
                        DossierId = dossier.DossierId,
                        
                        Actif = dossier.Actif

                    });
                }
            }
            return Dossiers;
        }

        public bool IdExist(int ID)
        {
            var Dossier = _dossierRepository.GetById(ID);
            if (Dossier == null)
                return false;
            return true;
        }

        public virtual async Task<DossierDTO?> AddDossier(NewDossierDTO Dossier)
        {
            if (Dossier == null) throw new ArgumentNullException(nameof(Dossier), "Aucune donnée à enregistrer");

            if (DossierExist(Dossier)) throw new ArgumentException("Le dossier existe déjà.");

            var newDossier = new Dossier()
            {
                DateArrivee = Dossier.DateArrivee,
                DureeSejourJours = Dossier.DureeSejourJours,
                TypeVoyageId =Dossier.TypeVoyageId,
                NumeroVol = Dossier.NumeroVol,
                Lieu = Dossier.Lieu,
                Actif = Dossier.Actif
            };

            var addedDossier = await _dossierRepository.Add(newDossier);
            return addedDossier != null ? new DossierDTO()
            {
                DossierId = addedDossier.DossierId,
                DateArrivee = addedDossier.DateArrivee,
                DureeSejourJours = addedDossier.DureeSejourJours,
                TypeVoyageId = addedDossier.TypeVoyageId,
                NumeroVol = addedDossier.NumeroVol,
                Lieu = addedDossier.Lieu,
                Actif = addedDossier.Actif
            } : null;
        }

        public virtual async Task<DossierDTO> UpdateDossier(DossierDTO Dossier)
        {
            var existingDossier = await _dossierRepository.GetById(Dossier.DossierId);

            if (existingDossier == null) throw new ArgumentException("Dossier introuvable.");

            
            existingDossier.Actif = Dossier.Actif;

            var updatedDossier = await _dossierRepository.UpdateAsync(existingDossier);
            return updatedDossier != null ? new DossierDTO()
            {
                DossierId = updatedDossier.DossierId,
                DateArrivee = updatedDossier.DateArrivee,
                DureeSejourJours = updatedDossier.DureeSejourJours,
                TypeVoyageId = updatedDossier.TypeVoyageId,
                NumeroVol = updatedDossier.NumeroVol,
                Lieu = updatedDossier.Lieu,
                Actif = updatedDossier.Actif
            } : throw new Exception("Impossible de mettre à jour le dossier.");
        }

        public virtual async Task<List<DossierDTO>> DeleteDossier(int ID)
        {
            var deletedDossiers = await _dossierRepository.DeleteAsync(ID);
            return deletedDossiers.Select(dossier => new DossierDTO
            {
                DossierId = dossier.DossierId,
                DateArrivee = dossier.DateArrivee,
                DureeSejourJours = dossier.DureeSejourJours,
                TypeVoyageId = dossier.TypeVoyageId,
                NumeroVol = dossier.NumeroVol,
                Lieu = dossier.Lieu,
                Actif = dossier.Actif
            }).ToList();
        }

    }
}
