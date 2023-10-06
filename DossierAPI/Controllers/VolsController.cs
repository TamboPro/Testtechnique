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
    public class VolsController : ControllerBase
    {
        private readonly DossierContext _context;

        public VolsController(DossierContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de tous les Vols
        /// </summary>
        /// <returns> Liste des Vols</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            if (_context.Vols == null)
            {
                return NotFound();
            }
            return await _context.Vols.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un Vol dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id du Vol à récupérer</param>
        /// <returns>Retourne le Vol demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">Vol non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vol>> GetVol(Guid id)
        {
            if (_context.Vols == null)
            {
                return NotFound();
            }
            var Vol = await _context.Vols.FindAsync(id);

            if (Vol == null)
            {
                return NotFound();
            }

            return Vol;
        }

        /// <summary>
        /// Mise à jour du Vol
        /// </summary>
        /// <param name="id">id du Vol à mettre à jour</param>
        /// <param name="Vol">Nouvelles informations du Vol</param>
        /// <returns></returns>
        /// <response code="204">Vol mise à jour</response>
        /// <response code="400">id différent de l'id du Vol envoyé</response>
        /// <response code="404">la Vol n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVol(Guid id, Vol Vol)
        {
            if (id != Vol.IdVol)
            {
                return BadRequest();
            }

            _context.Entry(Vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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
        /// Création d'un Vol
        /// </summary>
        /// <param name="Vol">Vol à créer</param>
        /// <returns>Retourne le Vol créé</returns>
        /// <response code="201">Le Vol a été créé</response>
        /// <response code="409">Le Vol existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Vol>> PostVol(Vol Vol)
        {
            if (_context.Vols == null)
            {
                return Problem("Entity set 'VolContext.Vols'  is null.");
            }


            Vol.IdVol = Guid.NewGuid();               
            

            _context.Vols.Add(Vol);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VolExists(Vol.IdVol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVol", new { id = Vol.IdVol }, Vol);
        }

        /// <summary>
        /// Suppression du Vol
        /// </summary>
        /// <param name="id">id du Vol à supprimer</param>
        /// <returns>Retourne le Vol supprimé</returns>
        /// <response code="200">le Vol a été supprimé</response>
        /// <response code="404">le Vol n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVol(Guid id)
        {
            if (_context.Vols == null)
            {
                return NotFound();
            }
            var Vol = await _context.Vols.FindAsync(id);
            if (Vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(Vol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolExists(Guid id)
        {
            return (_context.Vols?.Any(e => e.IdVol == id)).GetValueOrDefault();
        }
    }
}
