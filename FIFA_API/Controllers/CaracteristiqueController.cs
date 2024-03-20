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
    public class CaracteristiqueController : ControllerBase
    {
        private readonly IDataRepository<Caracteristique> dataRepository;

        public CaracteristiqueController(IDataRepository<Caracteristique> context)
        {
            dataRepository = context;
        }

        // GET: api/Caracteristique
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetCaracteristique()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Caracteristique/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Caracteristique>> GetCaracteristiqueById(int id)
        {
            var caract = await dataRepository.GetByIdAsync(id);

            if (caract == null)
            {
                return NotFound();
            }
            return caract;
        }

        // PUT: api/Caracteristique/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCaracteristique(int id, Caracteristique caracteristique)
        {
            if (id != caracteristique.CaracteristiqueId)
            {
                return BadRequest();
            }
            var carToUpdate = await dataRepository.GetByIdAsync(id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(carToUpdate.Value, caracteristique);
                return NoContent();
            }
        }

        // POST: api/Caracteristique
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Caracteristique>> PostCaracteristique(Caracteristique caracteristique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(caracteristique);
            return CreatedAtAction("GetById", new { id = caracteristique.CaracteristiqueId }, caracteristique);
        }

        // DELETE: api/Caracteristique/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristique(int id)
        {
            var caract = await dataRepository.GetByIdAsync(id);
            if (caract == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(caract.Value);
            return NoContent();
        }

        /*private bool CaracteristiqueExists(int id)
        {
            return (dataRepository.Caracteristique?.Any(e => e.CaracteristiqueId == id)).GetValueOrDefault();
        }*/
    }
}
