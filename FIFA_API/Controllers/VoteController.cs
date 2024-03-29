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
using System.Security.Cryptography;
using System.Threading;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IDataRepository3clues<Vote> dataRepository;

        public VoteController(IDataRepository3clues<Vote> context)
        {
            dataRepository = context;
        }

        // GET: api/Vote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetVote()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Vote/5
        [HttpGet]
        [Route("[action]/{utlid}/{theid}/{jouid}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vote>> GetVotById(int utlid, int theid, int jouid)
        {
            var vote = await dataRepository.GetByIdAsync(utlid, theid, jouid);

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }

        // PUT: api/Vote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVote(int utlid, int theid, int jouid, Vote vote)
        {
            if (utlid != vote.UtilisateurId && theid != vote.ThemeId && jouid != vote.JoueurId)
            {
                return BadRequest();
            }
            var votToUpdate = await dataRepository.GetByIdAsync(utlid, theid, jouid);
            if (votToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(votToUpdate.Value, vote);
                return NoContent();
            }
        }

        // POST: api/Vote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Vote>> PostVote(Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(vote);
            return CreatedAtAction("GetById", new { utlid = vote.UtilisateurId, theid = vote.ThemeId, jouid = vote.JoueurId }, vote);
        }

        // DELETE: api/Vote/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVote(int utlid, int theid, int jouid)
        {
            var vote = await dataRepository.GetByIdAsync(utlid, theid, jouid);
            if (vote == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(vote.Value);

            return NoContent();
        }
    }
}
