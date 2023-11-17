using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProduitAPI.DTOs;
using ProduitAPI.Services;
using System;
using System.Collections.Generic;

namespace ProduitAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les opérations sur les hôtels.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Obtient la liste de tous les hôtels.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HotelDTO>))]
        public ActionResult<List<HotelDTO>> GetHotels()
        {
            var hotels = _hotelService.GetHotels();
            return Ok(hotels);
        }

        /// <summary>
        /// Obtient un hôtel spécifique en fonction de l'ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> GetHotel(int id)
        {
            var hotel = _hotelService.GetHotel(id);
            if (hotel == null)
            {
                return NotFound("Hotel non trouvé");
            }
            return Ok(hotel);
        }

        /// <summary>
        /// Ajoute un nouvel hôtel.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<HotelDTO> AddHotel(NewHotelDTO newHotel)
        {
            try
            {
                var addedHotel = _hotelService.AddHotel(newHotel);
                if (addedHotel == null)
                {
                    return BadRequest("Une erreur s'est produite pendant l'enregistrement.");
                }
                else
                {
                    return Ok(addedHotel);
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Met à jour un hôtel existant.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> UpdateHotel(int id, HotelDTO hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest("IDs ne correspondent pas.");
            }

            if (!_hotelService.IdExist(id))
            {
                return NotFound("Enregistrement non trouvé.");
            }

            try
            {
                var updatedHotel = _hotelService.UpdateHotel(hotel);
                if (updatedHotel == null)
                {
                    return NotFound("Hotel non trouvé");
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Supprime un hôtel en fonction de l'ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HotelDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<HotelDTO>> DeleteHotel(int id)
        {
            try
            {
                if (!_hotelService.IdExist(id))
                    return NotFound("Enregistrement non trouvé");

                var deletedHotels = _hotelService.DeleteHotel(id);
                return Ok(deletedHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
