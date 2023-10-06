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
    public class CategoriesController : ControllerBase
    {
        private readonly ProduitContext _context;

        public CategoriesController(ProduitContext context)
        {
            _context = context;
        } 

        /// <summary>
        /// Récupération de toutes les catégorie
        /// </summary>
        /// <returns> Liste des catégorie</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// Récupération d'une catégorie dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id de la catégorie à récupérer</param>
        /// <returns>Retourne la catégorie demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">catégorie non trouvée</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Categorie>> GetCategorie(Guid id)
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var categorie = await _context.Categories.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        /// <summary>
        /// Mise à jour de la catégorie
        /// </summary>
        /// <param name="id">id de la catégorie à mettre à jour</param>
        /// <param name="catégorie">Nouvelles informations de la catégorie</param>
        /// <returns></returns>
        /// <response code="204">catégorie mis à jour</response>
        /// <response code="400">id différent de l'id de la catégorie envoyée</response>
        /// <response code="404">La catégorie n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCategorie(Guid id, Categorie categorie)
        {
            if (id != categorie.IdCategorie)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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
        /// Création d'une catégorie
        /// </summary>
        /// <param name="catégorie">catégorie à créer</param>
        /// <returns>Retourne la catégorie créée</returns>
        /// <response code="201">La catégorie a été créée</response>
        /// <response code="409">La catégorie existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {
          if (_context.Categories == null)
          {
              return Problem("Entity set 'ProduitContext.Categories'  is null.");
          }

             categorie.IdCategorie = Guid.NewGuid();

            _context.Categories.Add(categorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategorieExists(categorie.IdCategorie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategorie", new { id = categorie.IdCategorie }, categorie);
        }

        /// <summary>
        /// Suppression de la catégorie
        /// </summary>
        /// <param name="id">id de la catégorie à supprimer</param>
        /// <returns>Retourne la catégorie supprimé</returns>
        /// <response code="200">La catégorie a été supprimé</response>
        /// <response code="404">La catégorie n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategorie(Guid id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieExists(Guid id)
        {
            return (_context.Categories?.Any(e => e.IdCategorie == id)).GetValueOrDefault();
        }
    }
}
