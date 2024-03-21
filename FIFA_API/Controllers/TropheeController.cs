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
    public class TropheeController : ControllerBase
    {
        private readonly IDataRepository<Trophee> dataRepository;

        public TropheeController(IDataRepository<Trophee> context)
        {
            dataRepository = context;
        }

        // GET: api/Trophee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trophee>>> GetTrophee()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Trophee/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Trophee>> GetTropheeById(int id)
        {
            var trophee = await dataRepository.GetByIdAsync(id);

            if (trophee == null)
            {
                return NotFound();
            }

            return trophee;
        }

        // PUT: api/Trophee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTrophee(int id, Trophee trophee)
        {
            if (id != trophee.TropheeId)
            {
                return BadRequest();
            }

            var troToUpdate = await dataRepository.GetByIdAsync(id);
            if (troToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(troToUpdate.Value, trophee);
                return NoContent();
            }
        }

        // POST: api/Trophee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Trophee>> PostTrophee(Trophee trophee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(trophee);
            return CreatedAtAction("GetById", new { id = trophee.TropheeId }, trophee);
        }

        // DELETE: api/Trophee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrophee(int id)
        {
            var trophee = await dataRepository.GetByIdAsync(id);
            if (trophee == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(trophee.Value);
            return NoContent();
        }

        /*private bool TropheeExists(int id)
        {
            return (dataRepository.Trophee?.Any(e => e.TropheeId == id)).GetValueOrDefault();
        }*/
    }
}
