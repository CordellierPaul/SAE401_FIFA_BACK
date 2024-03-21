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
    public class PosteController : ControllerBase
    {
        private readonly IDataRepository<Poste> dataRepository;

        public PosteController(IDataRepository<Poste> context)
        {
            dataRepository = context;
        }

        // GET: api/Poste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poste>>> GetPoste()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Poste/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Poste>> GetPosteById(int id)
        {
            var poste = await dataRepository.GetByIdAsync(id);

            if (poste == null)
            {
                return NotFound();
            }

            return poste;
        }

        // PUT: api/Poste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPoste(int id, Poste poste)
        {
            if (id != poste.PosteId)
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
                await dataRepository.UpdateAsync(actToUpdate.Value, poste);
                return NoContent();
            }
        }

        // POST: api/Poste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Poste>> PostPoste(Poste poste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(poste);
            return CreatedAtAction("GetById", new { id = poste.PosteId }, poste);

        }

        // DELETE: api/Poste/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePoste(int id)
        {
            var poste = await dataRepository.GetByIdAsync(id);
            if (poste == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(poste.Value);

            return NoContent();
        }

        //private bool PosteExists(int id)
        //{
        //    return (dataRepository.Poste?.Any(e => e.PosteId == id)).GetValueOrDefault();
        //}
    }
}
