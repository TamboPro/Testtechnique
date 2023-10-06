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
    public class CompagniesController : ControllerBase
    {
        private readonly DossierContext _context;

        public CompagniesController(DossierContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de toutes les Compagnies
        /// </summary>
        /// <returns> Liste des Compagnies</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnies()
        {
            if (_context.Compagnies == null)
            {
                return NotFound();
            }
            return await _context.Compagnies.ToListAsync();
        }

        /// <summary>
        /// Récupération d'une Compagnie dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id de la Compagnie à récupérer</param>
        /// <returns>Retourne la Compagnie demandée</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">Compagnie non trouvée</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compagnie>> GetCompagnie(Guid id)
        {
            if (_context.Compagnies == null)
            {
                return NotFound();
            }
            var Compagnie = await _context.Compagnies.FindAsync(id);

            if (Compagnie == null)
            {
                return NotFound();
            }

            return Compagnie;
        }

        /// <summary>
        /// Mise à jour de la Compagnie
        /// </summary>
        /// <param name="id">id de la Compagnie à mettre à jour</param>
        /// <param name="Compagnie">Nouvelles informations de l"Compagnie</param>
        /// <returns></returns>
        /// <response code="204">Compagnie mise à jour</response>
        /// <response code="400">id différent de l'id de la Compagnie envoyé</response>
        /// <response code="404">la Compagnie n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCompagnie(Guid id, Compagnie Compagnie)
        {
            if (id != Compagnie.IdCompagnie)
            {
                return BadRequest();
            }

            _context.Entry(Compagnie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompagnieExists(id))
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
        /// Création d'une Compagnie
        /// </summary>
        /// <param name="Compagnie">Compagnie à créer</param>
        /// <returns>Retourne la Compagnie créée</returns>
        /// <response code="201">La Compagnie a été créée</response>
        /// <response code="409">La Compagnie existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Compagnie>> PostCompagnie(Compagnie Compagnie)
        {
            if (_context.Compagnies == null)
            {
                return Problem("Entity set 'ProduitContext.Compagnies'  is null.");
            }

             Compagnie.IdCompagnie = Guid.NewGuid();
            _context.Compagnies.Add(Compagnie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompagnieExists(Compagnie.IdCompagnie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompagnie", new { id = Compagnie.IdCompagnie }, Compagnie);
        }

        /// <summary>
        /// Suppression de la Compagnie
        /// </summary>
        /// <param name="id">id de la Compagnie à supprimer</param>
        /// <returns>Retourne la Compagnie supprimée</returns>
        /// <response code="200">la Compagnie a été supprimée</response>
        /// <response code="404">la Compagnie n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompagnie(Guid id)
        {
            if (_context.Compagnies == null)
            {
                return NotFound();
            }
            var Compagnie = await _context.Compagnies.FindAsync(id);
            if (Compagnie == null)
            {
                return NotFound();
            }

            _context.Compagnies.Remove(Compagnie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompagnieExists(Guid id)
        {
            return (_context.Compagnies?.Any(e => e.IdCompagnie == id)).GetValueOrDefault();
        }
    }
}
