using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProduitAPI.DAL;
using ProduitAPI.Models;
using ProduitAPI.ViewModels;

namespace ProduitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly ProduitContext _context;

        public ProduitsController(ProduitContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de tous les produits
        /// </summary>
        /// <returns> Liste des produits</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
          if (_context.Produits == null)
          {
              return NotFound();
          }
            return await _context.Produits.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un produit dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id du produit à récupérer</param>
        /// <returns>Retourne le produit demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">produit non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produit>> GetProduit(Guid id)
        {
          if (_context.Produits == null)
          {
              return NotFound();
          }
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        /// <summary>
        /// Mise à jour du produit
        /// </summary>
        /// <param name="id">id du produit à mettre à jour</param>
        /// <param name="produit">Nouvelles informations du produit</param>
        /// <returns></returns>
        /// <response code="204">produit mise à jour</response>
        /// <response code="400">id différent de l'id du produit envoyé</response>
        /// <response code="404">la produit n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduit(Guid id, Produit produit)
        {
            if (id != produit.IdProduit)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
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
        /// Création d'un produit
        /// </summary>
        /// <param name="produit">produit à créer</param>
        /// <returns>Retourne le produit créé</returns>
        /// <response code="201">Le produit a été créé</response>
        /// <response code="409">Le produit existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
          if (_context.Produits == null)
          {
              return Problem("Entity set 'ProduitContext.Produits'  is null.");
          }
            
           produit.IdProduit = Guid.NewGuid();
            _context.Produits.Add(produit);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitExists(produit.IdProduit))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduit", new { id = produit.IdProduit }, produit);
        }

        /// <summary>
        /// Suppression du produit
        /// </summary>
        /// <param name="id">id du produit à supprimer</param>
        /// <returns>Retourne le produit supprimé</returns>
        /// <response code="200">le produit a été supprimé</response>
        /// <response code="404">le produit n'existe pas</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduit(Guid id)
        {
            if (_context.Produits == null)
            {
                return NotFound();
            }
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitExists(Guid id)
        {
            return (_context.Produits?.Any(e => e.IdProduit == id)).GetValueOrDefault();
        }
    }
}
