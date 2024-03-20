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
    public class FilmController : ControllerBase
    {
        private readonly IDataRepository<Film> dataRepository;

        public FilmController(IDataRepository<Film> context)
        {
            dataRepository = context;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilm()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Film/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Film>> GetFilmById(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }
            return categorie;
        }

        // PUT: api/Film/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest();
            }
            var filToUpdate = await dataRepository.GetByIdAsync(id);
            if (filToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(filToUpdate.Value, film);
                return NoContent();
            }
        }

        // POST: api/Film
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(film);
            return CreatedAtAction("GetById", new { id = film.FilmId }, film);
        }

        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(categorie.Value);
            return NoContent();
        }

        /*private bool FilmExists(int id)
        {
            return (dataRepository.Film?.Any(e => e.FilmId == id)).GetValueOrDefault();
        }*/
    }
}
