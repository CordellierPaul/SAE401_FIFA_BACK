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
    public class MonnaieController : ControllerBase
    {
        private readonly IDataRepository<Monnaie> dataRepository;

        public MonnaieController(IDataRepository<Monnaie> context)
        {
            dataRepository = context;
        }

        // GET: api/Monnaie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monnaie>>> GetMonnaie()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Monnaie/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Monnaie>> GetMonnaieById(int id)
        {
            var monnaie = await dataRepository.GetByIdAsync(id);

            if (monnaie == null)
            {
                return NotFound();
            }

            return monnaie;
        }

        // PUT: api/Monnaie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutMonnaie(int id, Monnaie monnaie)
        {
            if (id != monnaie.MonnaieId)
            {
                return BadRequest();
            }
            var medToUpdate = await dataRepository.GetByIdAsync(id);
            if (medToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(medToUpdate.Value, monnaie);
                return NoContent();
            }
        }

        // POST: api/Monnaie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Monnaie>> PostMonnaie(Monnaie monnaie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(monnaie);
            return CreatedAtAction("GetById", new { id = monnaie.MonnaieId }, monnaie);

        }

        // DELETE: api/Monnaie/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMonnaie(int id)
        {
            var monnaie = await dataRepository.GetByIdAsync(id);
            if (monnaie == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(monnaie.Value);

            return NoContent();
        }

        //private bool MonnaieExists(int id)
        //{
        //    return (dataRepository.Monnaie?.Any(e => e.MonnaieId == id)).GetValueOrDefault();
        //}
    }
}
