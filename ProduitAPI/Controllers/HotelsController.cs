using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProduitAPI.DAL;
using ProduitAPI.Models;

namespace ProduitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ProduitContext _context;

        public HotelsController(ProduitContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de tous les hôtels
        /// </summary>
        /// <returns> Liste des hôtels</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un hôtel dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id de l'hôtel à récupérer</param>
        /// <returns>Retourne l'hôtel demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">hôtel non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hotel>> GetHotel(Guid id)
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        /// <summary>
        /// Mise à jour de l'hôtel
        /// </summary>
        /// <param name="id">id de l'hôtel à mettre à jour</param>
        /// <param name="hôtel">Nouvelles informations de l"hôtel</param>
        /// <returns></returns>
        /// <response code="204">hôtel mis à jour</response>
        /// <response code="400">id différent de l'id de l'hôtel envoyé</response>
        /// <response code="404">L'hôtel n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutHotel(Guid id, Hotel hotel)
        {
            if (id != hotel.IdHotel)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Création d'un hôtel
        /// </summary>
        /// <param name="hôtel">hôtel à créer</param>
        /// <returns>Retourne l'hôtel créé</returns>
        /// <response code="201">L'hôtel a été créée</response>
        /// <response code="409">L'hôtel existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
          if (_context.Hotels == null)
          {
              return Problem("Entity set 'ProduitContext.Hotels'  is null.");
          }
           
           
            hotel.IdHotel = Guid.NewGuid();
            _context.Hotels.Add(hotel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.IdHotel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotel", new { id = hotel.IdHotel }, hotel);
        }

        /// <summary>
        /// Suppression de l'hôtel
        /// </summary>
        /// <param name="id">id de l'hôtel à supprimer</param>
        /// <returns>Retourne l'hôtel supprimé</returns>
        /// <response code="200">L'hôtel a été supprimé</response>
        /// <response code="404">L'hôtel n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(Guid id)
        {
            return (_context.Hotels?.Any(e => e.IdHotel == id)).GetValueOrDefault();
        }
    }
}
