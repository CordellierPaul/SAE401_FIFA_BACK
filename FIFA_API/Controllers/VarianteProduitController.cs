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
    public class VarianteProduitController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<VarianteProduit> dataRepository;

        public VarianteProduitController(IDataRepositoryWithoutStr<VarianteProduit> context)
        {
            dataRepository = context;
        }

        // GET: api/VarianteProduit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VarianteProduit>>> GetVarianteProduit()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/VarianteProduit/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VarianteProduit>> GetVarianteProduit(int id)
        {
            var varianteProduit = await dataRepository.GetByIdAsync(id);

            if (varianteProduit == null)
            {
                return NotFound();
            }

            return varianteProduit;
        }

        // PUT: api/VarianteProduit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVarianteProduit(int id, VarianteProduit varianteProduit)
        {
            if (id != varianteProduit.VarianteProduitId)
            {
                return BadRequest();
            }

            var troToUpdate = await dataRepository.GetByIdAsync(id);
            if (troToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(troToUpdate.Value, varianteProduit);
                return NoContent();
            }
        }

        // POST: api/VarianteProduit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VarianteProduit>> PostVarianteProduit(VarianteProduit varianteProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(varianteProduit);
            return CreatedAtAction("GetById", new { id = varianteProduit.VarianteProduitId }, varianteProduit);
        }

        // DELETE: api/VarianteProduit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVarianteProduit(int id)
        {
            var varianteProduit = await dataRepository.GetByIdAsync(id);
            if (varianteProduit == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(varianteProduit.Value);
            return NoContent();
        }

    }
}