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
    public class AdresseController : ControllerBase
    {
        private readonly IDataRepository<Adresse> dataRepository;

        public AdresseController(IDataRepository<Adresse> context)
        {
            dataRepository = context;
        }

        // GET: api/Adresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresse()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Adresse/5
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresse(int id)
        {
            var adresse = await dataRepository.GetByIdAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }
            return adresse;
        }

        // PUT: api/Adresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.AdresseId)
            {
                return BadRequest();
            }
            var adrToUpdate = await dataRepository.GetByIdAsync(id);
            if (adrToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(adrToUpdate.Value, adresse);
                return NoContent();
            }
        }

        // POST: api/Adresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(adresse);
            return CreatedAtAction("GetById", new { id = adresse.AdresseId }, adresse);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var adresse = await dataRepository.GetByIdAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(adresse.Value);
            return NoContent();
        }

        /*private bool AdresseExists(int id)
        {
            return (dataRepository.Adresse?.Any(e => e.AdresseId == id)).GetValueOrDefault();
        }*/
    }
}
