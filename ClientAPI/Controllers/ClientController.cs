using ClientAPI.DTOs;
using ClientAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Récupère tous les clients.
        /// </summary>
        [HttpGet]
        public ActionResult<List<ClientDTO>> GetClients()
        {
            var Clients = _clientService.GetClients();
            return Ok(Clients);
        }

        /// <summary>
        /// Récupère un client spécifique par ID.
        /// </summary>
        /// <param name="id">Identifiant du client</param>
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClient(int id)
        {
            var client = _clientService.GetClient(id);
            if (client == null)
                return NotFound("Client non trouvé");

            return Ok(client);
        }

        /// <summary>
        /// Ajoute un nouveau client.
        /// </summary>
        /// <param name="newClient">Détails du nouveau client</param>
        [HttpPost]
        public ActionResult<ClientDTO> AddClient(NewClientDTO newClient)
        {
            try
            {
                var addedClient = _clientService.AddClient(newClient);
                if (addedClient == null)
                    return BadRequest("Une erreur s'est produite pendant l'enregistrement.");

                return Ok(addedClient);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Met à jour les détails d'un client existant.
        /// </summary>
        /// <param name="id">Identifiant du client</param>
        /// <param name="client">Détails du client mis à jour</param>
        [HttpPut("{id}")]
        public ActionResult<ClientDTO> UpdateClient(int id, ClientDTO client)
        {
            if (id != client.ClientId)
                return BadRequest("IDs ne correspondent pas.");

            if (!_clientService.IdExist(id))
                return NotFound("Enregistrement non trouvé.");

            // ... Vérifications supplémentaires ...

            try
            {
                var updatedClient = _clientService.UpdateClient(client);
                if (updatedClient == null)
                    return NotFound("Client non trouvé");

                return Ok(updatedClient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Supprime un client existant.
        /// </summary>
        /// <param name="id">Identifiant du client</param>
        [HttpDelete("{id}")]
        public ActionResult<List<ClientDTO>> DeleteClient(int id)
        {
            try
            {
                if (!_clientService.IdExist(id))
                    return NotFound("Enregistrement non trouvé");

                var deletedClients = _clientService.DeleteClient(id);
                return Ok(deletedClients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
