using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Moq;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivraisonController : ControllerBase
    {
        private readonly IDataRepository<Livraison> dataRepository;

        public LivraisonController(IDataRepository<Livraison> context)
        {
            dataRepository = context;
        }

        // GET: api/Livraison
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livraison>>> GetLivraison()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Livraison/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Livraison>> GetLivraisonById(int id)
        {
            var liv = await dataRepository.GetByIdAsync(id);

            if (liv == null)
            {
                return NotFound();
            }

            return liv;
        }

        // PUT: api/Livraison/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLivraison(int id, Livraison livraison)
        {
            if (id != livraison.LivraisonId)
            {
                return BadRequest();
            }

            var livToUpdate = await dataRepository.GetByIdAsync(id);
            if (livToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(livToUpdate.Value, livraison);
                return NoContent();
            }
        }

        // POST: api/Livraison
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Livraison>> PostLivraison(Livraison livraison)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(livraison);
            return CreatedAtAction("GetById", new { id = livraison.LivraisonId }, livraison);
        }

        // DELETE: api/Livraison/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivraison(int id)
        {
            var langue = await dataRepository.GetByIdAsync(id);
            if (langue == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(langue.Value);
            return NoContent();
        }

        /*private bool LivraisonExists(int id)
        {
            return (dataRepository.Livraison?.Any(e => e.LivraisonId == id)).GetValueOrDefault();
        }*/
    }
}
