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
    public class JoueurController : ControllerBase
    {
        private readonly IJoueurRepository dataRepository;

        public JoueurController(IJoueurRepository context)
        {
            dataRepository = context;
        }

        // GET: api/Joueur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueur()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Joueur/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Joueur>> GetJoueurById(int id)
        {
            var joueur = await dataRepository.GetByIdAsync(id);

            if (joueur == null)
            {
                return NotFound();
            }
            return joueur;
        }

        [HttpGet("GetByIds/{ids}")]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueurByIds(string ids)
        {
            int[] idArray = ids.Split(',').Select(int.Parse).ToArray();

            IEnumerable<Joueur> joueurs = await dataRepository.GetJoueursByIdsAsync(idArray);

            if (!joueurs.Any())
            {
                return NotFound();
            }

            return Ok(joueurs);
        }

        // PUT: api/Joueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutJoueur(int id, Joueur joueur)
        {
            if (id != joueur.JoueurId)
            {
                return BadRequest();
            }
            var catToUpdate = await dataRepository.GetByIdAsync(id);
            if (catToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(catToUpdate.Value, joueur);
                return NoContent();
            }
        }

        // POST: api/Joueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joueur>> PostJoueur(Joueur joueur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(joueur);
            return CreatedAtAction("GetById", new { id = joueur.JoueurId }, joueur);
        }

        // DELETE: api/Joueur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueur(int id)
        {
            var joueur = await dataRepository.GetByIdAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(joueur.Value);
            return NoContent();
        }

    }
}
