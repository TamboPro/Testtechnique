using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DossierAPI.DAL;
using DossierAPI.Models;

namespace DossierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly DossierContext _context;

        public ReservationsController(DossierContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de toutes les Reservations
        /// </summary>
        /// <returns> Liste des produits</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            return await _context.Reservations.ToListAsync();
        }

        /// <summary>
        /// Récupération d'une Reservation dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id de la Reservation à récupérer</param>
        /// <returns>Retourne la Reservation demandée</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">Reservation non trouvée</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetReservation(Guid id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        /// <summary>
        /// Mise à jour de la Reservation
        /// </summary>
        /// <param name="id">id de la Reservation à mettre à jour</param>
        /// <param name="Reservation">Nouvelles informations sur la Reservation</param>
        /// <returns></returns>
        /// <response code="204">Reservation mise à jour</response>
        /// <response code="400">id différent de la Reservation envoyée</response>
        /// <response code="404">la Reservation n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutReservation(Guid id, Reservation reservation)
        {
            if (id != reservation.IdReservation)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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
        /// Création d'une Reservation
        /// </summary>
        /// <param name="Reservation">Reservation à créer</param>
        /// <returns>Retourne la Reservation créée</returns>
        /// <response code="201">La Reservation a été créé</response>
        /// <response code="409">La Reservation existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ReservationContext.Reservations'  is null.");
            }

            reservation.IdReservation = Guid.NewGuid();
            _context.Reservations.Add(reservation);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservationExists(reservation.IdReservation))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReservation", new { id = reservation.IdReservation }, reservation);
        }

        /// <summary>
        /// Suppression de la Reservation
        /// </summary>
        /// <param name="id">id de la Reservation à supprimer</param>
        /// <returns>Retourne la Reservation supprimé</returns>
        /// <response code="200">la Reservation a été supprimé</response>
        /// <response code="404">la Reservation n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationExists(Guid id)
        {
            return (_context.Reservations?.Any(e => e.IdReservation == id)).GetValueOrDefault();
        }
    }
}
