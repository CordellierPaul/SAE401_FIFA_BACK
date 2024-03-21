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
    public class LangueController : ControllerBase
    {
        private readonly IDataRepository<Langue> dataRepository;

        public LangueController(IDataRepository<Langue> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Langue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Langue>>> GetLangue()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Langue/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Langue>> GetLangueById(int id)
        {
            var langue = await dataRepository.GetByIdAsync(id);

            if (langue == null)
            {
                return NotFound();
            }

            return langue;
        }

        // PUT: api/Langue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLangue(int id, Langue langue)
        {
            if (id != langue.LangueId)
            {
                return BadRequest();
            }

            var lanToUpdate = await dataRepository.GetByIdAsync(id);
            if (lanToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(lanToUpdate.Value, langue);
                return NoContent();
            }
        }

        // POST: api/Langue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Langue>> PostLangue(Langue langue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(langue);
            return CreatedAtAction("GetById", new { id = langue.LangueId }, langue);

        }

        // DELETE: api/Langue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLangue(int id)
        {
            var langue = await dataRepository.GetByIdAsync(id);
            if (langue == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(langue.Value);
            return NoContent();
        }

        //private bool LangueExists(int id)
        //{
        //    return (dataRepository.Langue?.Any(e => e.LangueId == id)).GetValueOrDefault();
        //}
    }
}
