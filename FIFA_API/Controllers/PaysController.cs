using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using System.Diagnostics;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly IPaysRepository dataRepository;

        public PaysController(IPaysRepository context)
        {
            dataRepository = context;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pays>>> GetPays()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Pays
        [HttpGet]
        [Route("[action]")]
        [ActionName("GetWhereProduitExists")]
        public async Task<ActionResult<IEnumerable<Pays>>> GetPaysWhereProduitExists()
        {
            return await dataRepository.GetPaysWhereProduitExists();
        }

        // GET: api/Pays/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pays>> GetPaysById(int id)
        {
            var pays = await dataRepository.GetByIdAsync(id);

            if (pays == null)
            {
                return NotFound();
            }

            return pays;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPays(int id, Pays pays)
        {
            if (id != pays.PaysId)
            {
                return BadRequest();
            }
            var actToUpdate = await dataRepository.GetByIdAsync(id);
            if (actToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(actToUpdate.Value, pays);
                return NoContent();
            }
        }

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pays>> PostPays(Pays pays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(pays);
            return CreatedAtAction("GetById", new { id = pays.PaysId }, pays);

        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePays(int id)
        {
            var pays = await dataRepository.GetByIdAsync(id);
            if (pays == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(pays.Value);

            return NoContent();
        }
    }
}
