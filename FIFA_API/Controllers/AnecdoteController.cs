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
    public class AnecdoteController : ControllerBase
    {
        private readonly IDataRepository<Anecdote> dataRepository;

        public AnecdoteController(IDataRepository<Anecdote> context)
        {
            dataRepository = context;
        }

        // GET: api/Anecdote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anecdote>>> GetAnecdote()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Anecdote/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Anecdote>> GetAnecdoteById(int id)
        {
            var anecdote = await dataRepository.GetByIdAsync(id);

            if (anecdote == null)
            {
                return NotFound();
            }
            return anecdote;
        }

        // PUT: api/Anecdote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAnecdote(int id, Anecdote anecdote)
        {
            if (id != anecdote.AnecdoteId)
            {
                return BadRequest();
            }
            var anectodeToUpdate = await dataRepository.GetByIdAsync(id);
            if (anectodeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(anectodeToUpdate.Value, anecdote);
                return NoContent();
            }
        }

        // POST: api/Anecdote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Anecdote>> PostAnecdote(Anecdote anecdote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(anecdote);
            return CreatedAtAction("GetById", new { id = anecdote.AnecdoteId }, anecdote);
        }

        // DELETE: api/Anecdote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnecdote(int id)
        {
            var anecdote = await dataRepository.GetByIdAsync(id);
            if (anecdote == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(anecdote.Value);
            return NoContent();
        }

    }
}
