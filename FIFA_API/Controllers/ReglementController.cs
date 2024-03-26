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

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglementController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<Reglement> dataRepository;

        public ReglementController(IDataRepositoryWithoutStr<Reglement> context)
        {
            dataRepository = context;
        }

        // GET: api/Reglement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reglement>>> GetReglement()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Reglement/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reglement>> GetReglementById(int id)
        {
            var reglement = await dataRepository.GetByIdAsync(id);

            if (reglement == null)
            {
                return NotFound();
            }

            return reglement;
        }

        // PUT: api/Reglement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutReglement(int id, Reglement reglement)
        {
            if (id != reglement.TransactionId)
            {
                return BadRequest();
            }
            var regToUpdate = await dataRepository.GetByIdAsync(id);
            if (regToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(regToUpdate.Value, reglement);
                return NoContent();
            }
        }

        // POST: api/Reglement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Reglement>> PostReglement(Reglement reglement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(reglement);
            return CreatedAtAction("GetById", new { id = reglement.TransactionId }, reglement);
        }

        // DELETE: api/Reglement/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReglement(int id)
        {
            var reglement = await dataRepository.GetByIdAsync(id);
            if (reglement == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(reglement.Value);

            return NoContent();
        }
    }
}
