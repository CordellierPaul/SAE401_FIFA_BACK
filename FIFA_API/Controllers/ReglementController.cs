using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglementController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ReglementController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Reglement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reglement>>> GetReglement()
        {
          if (_context.Reglement == null)
          {
              return NotFound();
          }
            return await _context.Reglement.ToListAsync();
        }

        // GET: api/Reglement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reglement>> GetReglement(int id)
        {
          if (_context.Reglement == null)
          {
              return NotFound();
          }
            var reglement = await _context.Reglement.FindAsync(id);

            if (reglement == null)
            {
                return NotFound();
            }

            return reglement;
        }

        // PUT: api/Reglement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReglement(int id, Reglement reglement)
        {
            if (id != reglement.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(reglement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReglementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reglement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reglement>> PostReglement(Reglement reglement)
        {
          if (_context.Reglement == null)
          {
              return Problem("Entity set 'FifaDbContext.Reglement'  is null.");
          }
            _context.Reglement.Add(reglement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReglement", new { id = reglement.TransactionId }, reglement);
        }

        // DELETE: api/Reglement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReglement(int id)
        {
            if (_context.Reglement == null)
            {
                return NotFound();
            }
            var reglement = await _context.Reglement.FindAsync(id);
            if (reglement == null)
            {
                return NotFound();
            }

            _context.Reglement.Remove(reglement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReglementExists(int id)
        {
            return (_context.Reglement?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
