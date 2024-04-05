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

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VilleController : ControllerBase
    {
        private readonly IDataRepository<Ville> dataRepository;

        public VilleController(IDataRepository<Ville> context)
        {
            dataRepository = context;
        }

        // GET: api/Ville
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ville>>> GetVille()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Ville/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ville>> GetVilleById(int id)
        {
            var ville = await dataRepository.GetByIdAsync(id);

            if (ville == null)
            {
                return NotFound();
            }

            return ville;
        }

        // GET: api/Ville/Annecy
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ville>> GetVilleByNom(string nom)
        {
            var ville = await dataRepository.GetByStringAsync(nom);

            if (ville == null)
            {
                return NotFound();
            }

            return ville;
        }

        // PUT: api/Ville/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVille(int id, Ville ville)
        {
            if (id != ville.VilleId)
            {
                return BadRequest();
            }

            var vilToUpdate = await dataRepository.GetByIdAsync(id);
            if (vilToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(vilToUpdate.Value, ville);
                return NoContent();
            }
        }

        // POST: api/Ville
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ville>> PostVille(Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(ville);
            return CreatedAtAction("GetVille", new { id = ville.VilleId }, ville);
        }

        // DELETE: api/Ville/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVille(int id)
        {
            var ville = await dataRepository.GetByIdAsync(id);
            if (ville == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(ville.Value);
            return NoContent();
        }

    }
}
