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
    public class BilletsController : ControllerBase
    {
        private readonly DossierContext _context;

        public BilletsController(DossierContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de tous les Billets
        /// </summary>
        /// <returns> Liste des Billets</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Billet>>> GetBillets()
        {
            if (_context.Billets == null)
            {
                return NotFound();
            }
            return await _context.Billets.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un Billet dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id du Billet à récupérer</param>
        /// <returns>Retourne le Billet demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">Billet non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Billet>> GetBillet(Guid id)
        {
            if (_context.Billets == null)
            {
                return NotFound();
            }
            var Billet = await _context.Billets.FindAsync(id);

            if (Billet == null)
            {
                return NotFound();
            }

            return Billet;
        }

        /// <summary>
        /// Mise à jour du Billet
        /// </summary>
        /// <param name="id">id du Billet à mettre à jour</param>
        /// <param name="Billet">Nouvelles informations du Billet</param>
        /// <returns></returns>
        /// <response code="204">Billet mise à jour</response>
        /// <response code="400">id différent de l'id du Billet envoyé</response>
        /// <response code="404">la Billet n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBillet(Guid id, Billet Billet)
        {
            if (id != Billet.IdBillet)
            {
                return BadRequest();
            }

            _context.Entry(Billet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilletExists(id))
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
        /// Création d'un Billet
        /// </summary>
        /// <param name="Billet">Le Billet à créer</param>
        /// <returns>Retourne le Billet créé</returns>
        /// <response code="201">Le Billet a été créé</response>
        /// <response code="409">Le Billet existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Billet>> PostBillet(Billet Billet)
        {
            if (_context.Billets == null)
            {
                return Problem("Entity set 'BilletContext.Billets'  is null.");
            }


            Billet.IdBillet = Guid.NewGuid();
            _context.Billets.Add(Billet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BilletExists(Billet.IdBillet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBillet", new { id = Billet.IdBillet }, Billet);
        }

        /// <summary>
        /// Suppression du Billet
        /// </summary>
        /// <param name="id">id du Billet à supprimer</param>
        /// <returns>Retourne le Billet supprimé</returns>
        /// <response code="200">le Billet a été supprimé</response>
        /// <response code="404">le Billet n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBillet(Guid id)
        {
            if (_context.Billets == null)
            {
                return NotFound();
            }
            var Billet = await _context.Billets.FindAsync(id);
            if (Billet == null)
            {
                return NotFound();
            }

            _context.Billets.Remove(Billet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BilletExists(Guid id)
        {
            return (_context.Billets?.Any(e => e.IdBillet == id)).GetValueOrDefault();
        }
    }
}
