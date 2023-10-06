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
    public class LignesController : ControllerBase
    {
        private readonly ProduitContext _context;

        public LignesController(ProduitContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de toutes les lignes
        /// </summary>
        /// <returns> Liste des lignes</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Ligne>>> GetLignes()
        {
          if (_context.Lignes == null)
          {
              return NotFound();
          }
            return await _context.Lignes.ToListAsync();
        }

        /// <summary>
        /// Récupération d'une ligne dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id de la ligne à récupérer</param>
        /// <returns>Retourne la ligne demandée</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">ligne non trouvée</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ligne>> GetLigne(Guid id)
        {
          if (_context.Lignes == null)
          {
              return NotFound();
          }
            var ligne = await _context.Lignes.FindAsync(id);

            if (ligne == null)
            {
                return NotFound();
            }

            return ligne;
        }

        /// <summary>
        /// Mise à jour de la ligne
        /// </summary>
        /// <param name="id">id de la ligne à mettre à jour</param>
        /// <param name="ligne">Nouvelles informations de l"ligne</param>
        /// <returns></returns>
        /// <response code="204">ligne mise à jour</response>
        /// <response code="400">id différent de l'id de la ligne envoyé</response>
        /// <response code="404">la ligne n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutLigne(Guid id, Ligne ligne)
        {
            if (id != ligne.IdLigne)
            {
                return BadRequest();
            }

            _context.Entry(ligne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigneExists(id))
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
        /// Création d'une ligne
        /// </summary>
        /// <param name="ligne">ligne à créer</param>
        /// <returns>Retourne la ligne créée</returns>
        /// <response code="201">La ligne a été créée</response>
        /// <response code="409">La ligne existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Ligne>> PostLigne(Ligne ligne)
        {
          if (_context.Lignes == null)
          {
              return Problem("Entity set 'ProduitContext.Lignes'  is null.");
          }
           ligne.IdLigne = Guid.NewGuid();
            _context.Lignes.Add(ligne);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LigneExists(ligne.IdLigne))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLigne", new { id = ligne.IdLigne }, ligne);
        }

        /// <summary>
        /// Suppression de la ligne
        /// </summary>
        /// <param name="id">id de la ligne à supprimer</param>
        /// <returns>Retourne la ligne supprimée</returns>
        /// <response code="200">la ligne a été supprimée</response>
        /// <response code="404">la ligne n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLigne(Guid id)
        {
            if (_context.Lignes == null)
            {
                return NotFound();
            }
            var ligne = await _context.Lignes.FindAsync(id);
            if (ligne == null)
            {
                return NotFound();
            }

            _context.Lignes.Remove(ligne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LigneExists(Guid id)
        {
            return (_context.Lignes?.Any(e => e.IdLigne == id)).GetValueOrDefault();
        }
    }
}
