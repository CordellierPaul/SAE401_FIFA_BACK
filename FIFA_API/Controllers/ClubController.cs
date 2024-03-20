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
    public class ClubController : ControllerBase
    {
        private readonly IDataRepository<Club> dataRepository;

        public ClubController(IDataRepository<Club> context)
        {
            dataRepository = context;
        }

        // GET: api/Club
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClub()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Club/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClubById(int id)
        {
            var club = await dataRepository.GetByIdAsync(id);

            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        // PUT: api/Club/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.ClubId)
            {
                return BadRequest();
            }
            var clubToUpdate = await dataRepository.GetByIdAsync(id);
            if (clubToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(clubToUpdate.Value, club);
                return NoContent();
            }
        }

        // POST: api/Club
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(club);
            return CreatedAtAction("GetById", new { id = club.ClubId }, club);
        }

        // DELETE: api/Club/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(categorie.Value);
            return NoContent();
        }

        /*private bool ClubExists(int id)
        {
            return (dataRepository.Club?.Any(e => e.ClubId == id)).GetValueOrDefault();
        }*/
    }
}
