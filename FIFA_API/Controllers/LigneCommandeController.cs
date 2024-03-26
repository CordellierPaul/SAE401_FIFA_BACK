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
    public class LigneCommandeController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<LigneCommande> dataRepository;

        public LigneCommandeController(IDataRepositoryWithoutStr<LigneCommande> context)
        {
            dataRepository = context;
        }

        // GET: api/LigneCommande
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigneCommande>>> GetLigneCommande()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/LigneCommande/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LigneCommande>> GetLigneCommandeById(int id)
        {
            var lignecommande = await dataRepository.GetByIdAsync(id);

            if (lignecommande == null)
            {
                return NotFound();
            }

            return lignecommande;
        }

        // PUT: api/LigneCommande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLigneCommande(int id, LigneCommande ligneCommande)
        {
            if (id != ligneCommande.LigneCommandeId)
            {
                return BadRequest();
            }
            var lcdToUpdate = await dataRepository.GetByIdAsync(id);
            if (lcdToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(lcdToUpdate.Value, ligneCommande);
                return NoContent();
            }
        }

        // POST: api/LigneCommande
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LigneCommande>> PostLigneCommande(LigneCommande ligneCommande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(ligneCommande);
            return CreatedAtAction("GetById", new { id = ligneCommande.LigneCommandeId }, ligneCommande);
        }

        // DELETE: api/LigneCommande/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLigneCommande(int id)
        {
            var ligneCommande = await dataRepository.GetByIdAsync(id);
            if (ligneCommande == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(ligneCommande.Value);
            return NoContent();
        }

        //private bool LigneCommandeExists(int id)
        //{
        //    return (dataRepository.LigneCommande?.Any(e => e.LigneCommandeId == id)).GetValueOrDefault();
        //}
    }
}
