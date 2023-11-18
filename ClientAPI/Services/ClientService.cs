using ClientAPI.DTOs;
using ClientAPI.IRepositories;
using ClientAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Services
{
    /// <summary>
    /// Service pour gérer les opérations liées aux clients.
    /// </summary>
    public class ClientService:IClientService
    {

        private readonly IClientRepository  _clientRepository;
        /// <summary>
        /// Constructeur du service ClientService
        /// </summary>
        /// <param name="clientRepository">Repository des clients</param>
        public ClientService(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Vérifie si un client existe déjà en fonction de certains critères.
        /// </summary>
        /// <param name="Client">Détails du client à vérifier</param>
        /// <returns>True si le client existe, sinon False</returns>
        public bool ClientExist(NewClientDTO Client)
        {
            var ClientFounded = _clientRepository.GetAllAsync().Result
                .Any(cli => (cli.Nom == Client.Nom && cli.Prenom == Client.Prenom && (cli.DateDeNaissance == Client.DateDeNaissance)) || (cli.Email == Client.Email && !cli.Email.Equals(string.Empty )) || (cli.NumeroTelephone == Client.NumeroTelephone && !cli.NumeroTelephone.Equals(string.Empty)));
              
            
            return ClientFounded;
        }

        /// <summary>
        /// Récupère les détails d'un client en fonction de son ID.
        /// </summary>
        /// <param name="ID">ID du client à récupérer</param>
        /// <returns>Détails du client récupéré</returns>
        public virtual  async Task<ClientDTO> GetClient(int ID)
        {
            var client = await  _clientRepository.GetById(ID);

            ClientDTO ClientFound = new ClientDTO();
            if (client != null)
            {
                ClientFound = new ClientDTO()
                {
                    ClientId = client.ClientId,
                    Nom = client.Nom,
                    Prenom = client.Prenom,
                    Adresse = client.Adresse,
                    DateDeNaissance = client.DateDeNaissance,
                    Email = client.Email,
                    NumeroTelephone = client.NumeroTelephone,
                    Nationalite = client.Nationalite,
                    Actif = client.Actif

                };
            }

            return ClientFound;
        }
        /// <summary>
        /// Récupère la liste de tous les clients.
        /// </summary>
        /// <returns>Liste de tous les clients</returns>
        public virtual  async Task<List<ClientDTO>> GetClients()
        {
            List<ClientDTO> Clients = new List<ClientDTO> ();
            var getClients = await _clientRepository.GetAllAsync();
            if (getClients != null)
            {
                foreach (var client in getClients)
                {
                    Clients.Add(new ClientDTO
                    {
                        ClientId = client.ClientId,
                        Nom = client.Nom,
                        Prenom = client.Prenom,
                        Adresse = client.Adresse,
                        DateDeNaissance = client.DateDeNaissance,
                        Email = client.Email,
                        NumeroTelephone = client.NumeroTelephone,
                        Nationalite = client.Nationalite,
                        Actif = client.Actif

                    });
                }
            }
            return Clients;
        }
        /// <summary>
        /// Vérifie l'existance ce d'un ID.
        /// </summary>
        /// <returns>true si l'ID existe et false si non</returns>
        public bool IdExist(int ID)
        {
            var Client = _clientRepository.GetById(ID);
            if (Client == null)
                return false;
            return true;
        }
        /// <summary>
        /// Récupère la liste de tous les clients.
        /// </summary>
        /// <returns>Client avec son ID si ssucès, null si echec</returns>
        public virtual async Task<ClientDTO?> AddClient(NewClientDTO Client)
        {
            if (Client == null) throw new ArgumentNullException(nameof(Client), "Aucune donnée à enregistrer");

            if (ClientExist(Client)) throw new ArgumentException("Le client existe déjà.");

            var newClient = new Client
            {
                Nom = Client.Nom,
                Prenom = Client.Prenom,
                Adresse = Client.Adresse,
                DateDeNaissance = Client.DateDeNaissance,
                Email = Client.Email,
                NumeroTelephone = Client.NumeroTelephone,
                Nationalite = Client.Nationalite,
                Actif = Client.Actif
            };

            var addedClient = await _clientRepository.Add(newClient);
            return addedClient != null ? new ClientDTO()
            {
                ClientId = addedClient.ClientId,
                Nom = addedClient.Nom,
                Prenom = addedClient.Prenom,
                Adresse = addedClient.Adresse,
                DateDeNaissance = addedClient.DateDeNaissance,
                Email = addedClient.Email,
                NumeroTelephone = addedClient.NumeroTelephone,
                Nationalite = addedClient.Nationalite,
                Actif = addedClient.Actif
            } : null;
        }
        /// <summary>
        /// Modifie un client.
        /// </summary>
        /// <returns>Client modifier</returns>
        public virtual async Task<ClientDTO> UpdateClient(ClientDTO Client)
        {
            var existingClient = await _clientRepository.GetById(Client.ClientId);

            if (existingClient == null) throw new ArgumentException("Client introuvable.");

            existingClient.Nom = Client.Nom;
            existingClient.Prenom = Client.Prenom;
            existingClient.Adresse = Client.Adresse;
            existingClient.DateDeNaissance = Client.DateDeNaissance;
            existingClient.Email = Client.Email;
            existingClient.NumeroTelephone = Client.NumeroTelephone;
            existingClient.Nationalite = Client.Nationalite;
            existingClient.Actif = Client.Actif;

            var updatedClient = await _clientRepository.UpdateAsync(existingClient);
            return updatedClient != null ? new ClientDTO()
            {
                ClientId = updatedClient.ClientId,
                Nom = updatedClient.Nom,
                Prenom = updatedClient.Prenom,
                Adresse = updatedClient.Adresse,
                DateDeNaissance = updatedClient.DateDeNaissance,
                Email = updatedClient.Email,
                NumeroTelephone = updatedClient.NumeroTelephone,
                Nationalite = updatedClient.Nationalite,
                Actif = updatedClient.Actif
            } : throw new Exception("Impossible de mettre à jour le client.");
        }
        /// <summary>
        /// Supprime un client à partir de so ID.
        /// </summary>
        /// <returns>Liste de tous les clients</returns>
        public virtual async Task<List<ClientDTO>> DeleteClient(int ID)
        {
            var deletedClients = await _clientRepository.DeleteAsync(ID);
            return deletedClients.Select(client => new ClientDTO
            {
                ClientId = client.ClientId,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                DateDeNaissance = client.DateDeNaissance,
                Email = client.Email,
                NumeroTelephone = client.NumeroTelephone,
                Nationalite = client.Nationalite,
                Actif = client.Actif
            }).ToList();
        }

    }
}
