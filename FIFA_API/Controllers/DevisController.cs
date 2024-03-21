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
    public class DevisController : ControllerBase
    {
        private readonly IDataRepository<Devis> dataRepository;

        public DevisController(IDataRepository<Devis> context)
        {
            dataRepository = context;
        }

        // GET: api/Devis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devis>>> GetDevis()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Devis/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Devis>> GetDevisById(int id)
        {
            var devis = await dataRepository.GetByIdAsync(id);

            if (devis == null)
            {
                return NotFound();
            }
            return devis;
        }

        // PUT: api/Devis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDevis(int id, Devis devis)
        {
            if (id != devis.DevisId)
            {
                return BadRequest();
            }
            var devToUpdate = await dataRepository.GetByIdAsync(id);
            if (devToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(devToUpdate.Value, devis);
                return NoContent();
            }
        }

        // POST: api/Devis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Devis>> PostDevis(Devis devis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(devis);

            return CreatedAtAction("GetById", new { id = devis.DevisId }, devis);
        }

        // DELETE: api/Devis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevis(int id)
        {
            var devis = await dataRepository.GetByIdAsync(id);
            if (devis == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(devis.Value);
            return NoContent();
        }

        /*private bool DevisExists(int id)
        {
            return (dataRepository.Devis?.Any(e => e.DevisId == id)).GetValueOrDefault();
        }*/
    }
}
