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
    public class ActiviteController : ControllerBase
    {
        private readonly IDataRepository<Activite> dataRepository;

        public ActiviteController(IDataRepository<Activite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Activite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivite()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Activite/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetActiviteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            var activite = await dataRepository.GetByIdAsync(id);

            if (activite == null)
            {
                return NotFound();
            }

            return activite;
        }

        // PUT: api/Activite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.ActiviteId)
            {
                return BadRequest();
            }
            var catToUpdate = await dataRepository.GetByIdAsync(id);
            if (catToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(catToUpdate.Value, activite);
                return NoContent();
            }
        }

        // POST: api/Activite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(activite);
            return CreatedAtAction("GetById", new { id = activite.ActiviteId }, activite);


        }

        // DELETE: api/Activite/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = await dataRepository.GetByIdAsync(id);
            if (activite == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(activite.Value);

            return NoContent();
        }

        /*private bool ActiviteExists(int id)
        {
            return (dataRepository.Activite?.Any(e => e.ActiviteId == id)).GetValueOrDefault();
        }*/
    }
}
