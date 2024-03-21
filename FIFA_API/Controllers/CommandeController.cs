using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<Commande> dataRepository;

        public CommandeController(IDataRepositoryWithoutStr<Commande> context)
        {
            dataRepository = context;
        }

        // GET: api/Commande
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Commande/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commande>> GetCommandeById(int id)
        {
            var commande = await dataRepository.GetByIdAsync(id);

            if (commande == null)
            {
                return NotFound();
            }
            return commande;
        }

        // PUT: api/Commande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.CommandeId)
            {
                return BadRequest();
            }
            var comToUpdate = await dataRepository.GetByIdAsync(id);
            if (comToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(comToUpdate.Value, commande);
                return NoContent();
            }
        }

        // POST: api/Commande
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(commande);
            return CreatedAtAction("GetById", new { id = commande.CommandeId }, commande);
        }

        // DELETE: api/Commande/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await dataRepository.GetByIdAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(commande.Value);
            return NoContent();
        }

        /*private bool CommandeExists(int id)
        {
            return (dataRepository.Commande?.Any(e => e.CommandeId == id)).GetValueOrDefault();
        }*/
    }
}
