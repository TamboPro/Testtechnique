using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class ClientsController : ControllerBase
    {
        private readonly ProduitContext _context;

        public ClientsController(ProduitContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Récupération de tous les clients
        /// </summary>
        /// <returns> Liste des clients triés par Nom et Prénom </returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            return await _context.Clients.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un client dont l'id est passé en paramètre
        /// </summary>
        /// <param name="id">id du client à récupérer</param>
        /// <returns>Retourne le client demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">client non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        /// <summary>
        /// Mise à jour d'un client
        /// </summary>
        /// <param name="id">id du client à mettre à jour</param>
        /// <param name="client">Nouvelles informations du client</param>
        /// <returns></returns>
        /// <response code="204">client mis à jour</response>
        /// <response code="400">id différent du code du client envoyé</response>
        /// <response code="404">Le client n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
        /// Création d'un client
        /// </summary>
        /// <param name="diplomes">client à créer</param>
        /// <returns>Retourne le client créé</returns>
        /// <response code="201">Le client a été créé</response>
        /// <response code="409">Le client existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'ProduitContext.Clients'  is null.");
          }


            _context.Clients.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            { 
                if (ClientExists(client.IdClient))
                {
                    return Conflict();
                }
                else { 

                    throw; 

                }
            }
            

            return CreatedAtAction("GetClient", new { id = client.IdClient }, client);
        }

        /// <summary>
        /// Suppression d'un client
        /// </summary>
        /// <param name="id">id du client à supprimer</param>
        /// <returns>Retourne le client supprimé</returns>
        /// <response code="200">Le client a été supprimé</response>
        /// <response code="404">Le client n'existe pas</response>
        [HttpDelete("{id}")]
        [HttpDelete("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(Guid id)
        {
            return (_context.Clients?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
