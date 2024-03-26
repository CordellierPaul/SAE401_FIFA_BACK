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
    public class GenreController : ControllerBase
    {
        private readonly IDataRepository<Genre> dataRepository;

        public GenreController(IDataRepository<Genre> context)
        {
            dataRepository = context;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Genre/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            var genre = await dataRepository.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest();
            }
            var genToUpdate = await dataRepository.GetByIdAsync(id);
            if (genToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(genToUpdate.Value, genre);
                return NoContent();
            }
        }

        // POST: api/Genre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(genre);
            return CreatedAtAction("GetById", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await dataRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(genre.Value);
            return NoContent();
        }

    }
}
