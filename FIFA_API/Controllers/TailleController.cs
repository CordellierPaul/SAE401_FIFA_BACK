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
    public class TailleController : ControllerBase
    {
        private readonly IDataRepository<Taille> dataRepository;

        public TailleController(IDataRepository<Taille> context)
        {
            dataRepository = context;
        }

        // GET: api/Taille
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taille>>> GetTaille()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Taille/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Taille>> GetTaille(int id)
        {
            var taille = await dataRepository.GetByIdAsync(id);

            if (taille == null)
            {
                return NotFound();
            }

            return taille;
        }

        // PUT: api/Taille/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTaille(int id, Taille taille)
        {
            if (id != taille.TailleId)
            {
                return BadRequest();
            }
            var taiToUpdate = await dataRepository.GetByIdAsync(id);
            if (taiToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(taiToUpdate.Value, taille);
                return NoContent();
            }
        }

        // POST: api/Taille
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Taille>> PostTaille(Taille taille)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(taille);
            return CreatedAtAction("GetById", new { id = taille.TailleId }, taille);
        }

        // DELETE: api/Taille/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTaille(int id)
        {
            var taille = await dataRepository.GetByIdAsync(id);
            if (taille == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(taille.Value);

            return NoContent();
        }
    }
}
