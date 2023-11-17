using DossierAPI.DTOs;
using DossierAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DossierAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les types de voyages.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TypeVoyageController : ControllerBase
    {
        private readonly ITypeVoyageService _typeVoyageService;

        public TypeVoyageController(ITypeVoyageService typeVoyageService)
        {
            _typeVoyageService = typeVoyageService ?? throw new ArgumentNullException(nameof(typeVoyageService));
        }

        /// <summary>
        /// Récupère tous les types de voyages disponibles.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<TypeVoyageDTO>>> GetTypeVoyages()
        {
            var typeVoyages = await _typeVoyageService.GetTypeVoyages();
            return Ok(typeVoyages);
        }

        /// <summary>
        /// Récupère un type de voyage spécifique par ID.
        /// </summary>
        /// <param name="id">Identifiant du type de voyage</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeVoyageDTO>> GetTypeVoyage(int id)
        {
            var typeVoyage = await _typeVoyageService.GetTypeVoyage(id);
            if (typeVoyage == null)
            {
                return NotFound();
            }

            return typeVoyage;
        }

        /// <summary>
        /// Ajoute un nouveau type de voyage.
        /// </summary>
        /// <param name="typeVoyage">Détails du nouveau type de voyage</param>
        [HttpPost]
        public async Task<ActionResult<TypeVoyageDTO>> AddTypeVoyage(NewTypeVoyageDTO typeVoyage)
        {
            try
            {
                var addedTypeVoyage = await _typeVoyageService.AddTypeVoyage(typeVoyage);
                return CreatedAtAction(nameof(GetTypeVoyage), new { id = addedTypeVoyage.TypeVoyageId }, addedTypeVoyage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Met à jour les détails d'un type de voyage existant.
        /// </summary>
        /// <param name="id">Identifiant du type de voyage</param>
        /// <param name="typeVoyage">Détails du type de voyage mis à jour</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeVoyageDTO>> UpdateTypeVoyage(int id, TypeVoyageDTO typeVoyage)
        {
            if (id != typeVoyage.TypeVoyageId)
            {
                return BadRequest();
            }

            try
            {
                var updatedTypeVoyage = await _typeVoyageService.UpdateTypeVoyage(typeVoyage);
                if (updatedTypeVoyage == null)
                {
                    return NotFound();
                }

                return updatedTypeVoyage;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Supprime un type de voyage existant.
        /// </summary>
        /// <param name="id">Identifiant du type de voyage</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TypeVoyageDTO>>> DeleteTypeVoyage(int id)
        {
            try
            {
                var deletedTypeVoyages = await _typeVoyageService.DeleteTypeVoyage(id);
                return Ok(deletedTypeVoyages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
