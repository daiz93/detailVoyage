using ProduitAPI.DTOs;
using ProduitAPI.IRepositories;
using ProduitAPI.Models;
using System;

namespace ProduitAPI.Services
{
    /// <summary>
    /// Service pour gérer les opérations liées aux hôtels.
    /// </summary>
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        /// <summary>
        /// Ajoute un nouvel hôtel.
        /// </summary>
        /// <param name="hotel">Détails du nouvel hôtel à ajouter</param>
        /// <returns>Retourne les détails de l'hôtel ajouté</returns>
        public async Task<HotelDTO?> AddHotel(NewHotelDTO hotel)
        {
            if (hotel == null) throw new ArgumentNullException(nameof(hotel), "Aucune donnée à enregistrer");

            if (HotelExist(hotel)) throw new ArgumentException("L'hotel existe déjà.");

            var newHotel = new Hotel
            {

                 Nom = hotel.Nom,
                 Description = hotel.Description,
                 Prix = hotel.Prix,
                 Fabricant = hotel.Fabricant,
                 NombreEtoiles = hotel.NombreEtoiles,
                 Ville = hotel.Ville,
                 Pays = hotel.Pays,
                 Adresse = hotel.Adresse,
                 Actif = hotel.Actif
            };

            var addedHotel = await _hotelRepository.Add(newHotel);
            return addedHotel != null ? new HotelDTO()
            {
                HotelId = addedHotel.ProduitId,
                Nom = addedHotel.Nom,
                Description = addedHotel.Description,
                Prix = addedHotel.Prix,
                Fabricant = addedHotel.Fabricant,
                NombreEtoiles = addedHotel.NombreEtoiles,
                Ville = addedHotel.Ville,
                Pays = addedHotel.Pays,
                Adresse = addedHotel.Adresse,
                Actif = addedHotel.Actif
            } : null;

        }

        /// <summary>
        /// Supprime un hôtel en fonction de son ID.
        /// </summary>
        /// <param name="ID">ID de l'hôtel à supprimer</param>
        /// <returns>Liste des hôtels après suppression</returns>
        public Task<List<HotelDTO>> DeleteHotel(int ID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Récupère les détails d'un hôtel en fonction de son ID.
        /// </summary>
        /// <param name="ID">ID de l'hôtel à récupérer</param>
        /// <returns>Détails de l'hôtel récupéré</returns>
        public async Task<HotelDTO> GetHotel(int ID)
        {
            var hotel = await _hotelRepository.GetById(ID);

            HotelDTO hotelFound = new HotelDTO();
            if (hotel != null)
            {
                hotelFound = new HotelDTO()
                {
                    HotelId = hotel.ProduitId,
                    Nom = hotel.Nom,
                    Description = hotel.Description,
                    Prix = hotel.Prix,
                    Fabricant = hotel.Fabricant,
                    NombreEtoiles = hotel.NombreEtoiles,
                    Ville = hotel.Ville,
                    Pays = hotel.Pays,
                    Adresse = hotel.Adresse,
                    Actif = hotel.Actif

                };
            }

            return hotelFound;
        }
        /// <summary>
        /// Récupère la liste de tous les hôtels.
        /// </summary>
        /// <returns>Liste de tous les hôtels</returns>
        public async Task<List<HotelDTO>> GetHotels()
        {
            List<HotelDTO> Typevoyages = new List<HotelDTO>();
            var getHotels = await _hotelRepository.GetAllAsync();
            if (getHotels != null)
            {
                foreach (var hotel   in getHotels)
                {
                    Typevoyages.Add(new HotelDTO()
                    {
                        HotelId = hotel.ProduitId,
                        Nom = hotel.Nom,
                        Description = hotel.Description,
                        Prix = hotel.Prix,
                        Fabricant = hotel.Fabricant,
                        NombreEtoiles = hotel.NombreEtoiles,
                        Ville = hotel.Ville,
                        Pays = hotel.Pays,
                        Adresse = hotel.Adresse,
                        Actif = hotel.Actif

                    });
                }
            }
            return Typevoyages;

            
        }
        /// <summary>
        /// Vérifie si un ID d'hôtel existe.
        /// </summary>
        /// <param name="ID">ID de l'hôtel à vérifier</param>
        /// <returns>True si l'ID existe, sinon False</returns>
        public bool IdExist(int ID)
        {
            var hotel = _hotelRepository.GetById(ID);
            if (hotel == null)
                return false;
            return true;
        }
        /// <summary>
        /// Vérifie si un hôtel existe déjà en fonction de certains critères.
        /// </summary>
        /// <param name="Hotel">Détails de l'hôtel à vérifier</param>
        /// <returns>True si l'hôtel existe, sinon False</returns>
        public bool HotelExist(NewHotelDTO Hotel)
        {
            var HotelFounded = _hotelRepository.GetAllAsync().Result
                .Any(cli => (cli.Nom == Hotel.Nom && cli.Ville == Hotel.Ville));


            return HotelFounded;
        }
        /// <summary>
        /// Met à jour les détails d'un hôtel.
        /// </summary>
        /// <param name="Hotel">Détails de l'hôtel à mettre à jour</param>
        /// <returns>Détails de l'hôtel mis à jour</returns>
        public Task<HotelDTO> UpdateHotel(HotelDTO Hotel)
        {
            throw new NotImplementedException();
        }
    }
}
