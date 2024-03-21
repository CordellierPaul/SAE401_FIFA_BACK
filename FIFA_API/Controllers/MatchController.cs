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
using Match = FIFA_API.Models.EntityFramework.Match;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<Match> dataRepository;

        public MatchController(IDataRepositoryWithoutStr<Match> context)
        {
            dataRepository = context;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatch()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Match>> GetMatchById(int id)
        {
            var match = await dataRepository.GetByIdAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        // PUT: api/Match/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.MatchId)
            {
                return BadRequest();
            }

            var matToUpdate = await dataRepository.GetByIdAsync(id);
            if (matToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(matToUpdate.Value, match);
                return NoContent();
            }
        }

        // POST: api/Match
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(match);
            return CreatedAtAction("GetById", new { id = match.MatchId }, match);
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await dataRepository.GetByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(match.Value);
            return NoContent();
        }

        /*private bool MatchExists(int id)
        {
            return (dataRepository.Match?.Any(e => e.MatchId == id)).GetValueOrDefault();
        }*/
    }
}
