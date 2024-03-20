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
    public class RemporteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public RemporteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Remporte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remporte>>> GetRemporte()
        {
          if (_context.Remporte == null)
          {
              return NotFound();
          }
            return await _context.Remporte.ToListAsync();
        }

        // GET: api/Remporte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Remporte>> GetRemporte(int id)
        {
          if (_context.Remporte == null)
          {
              return NotFound();
          }
            var remporte = await _context.Remporte.FindAsync(id);

            if (remporte == null)
            {
                return NotFound();
            }

            return remporte;
        }

        // PUT: api/Remporte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemporte(int id, Remporte remporte)
        {
            if (id != remporte.JoueurId)
            {
                return BadRequest();
            }

            _context.Entry(remporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemporteExists(id))
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

        // POST: api/Remporte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Remporte>> PostRemporte(Remporte remporte)
        {
          if (_context.Remporte == null)
          {
              return Problem("Entity set 'FifaDbContext.Remporte'  is null.");
          }
            _context.Remporte.Add(remporte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RemporteExists(remporte.JoueurId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRemporte", new { id = remporte.JoueurId }, remporte);
        }

        // DELETE: api/Remporte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemporte(int id)
        {
            if (_context.Remporte == null)
            {
                return NotFound();
            }
            var remporte = await _context.Remporte.FindAsync(id);
            if (remporte == null)
            {
                return NotFound();
            }

            _context.Remporte.Remove(remporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemporteExists(int id)
        {
            return (_context.Remporte?.Any(e => e.JoueurId == id)).GetValueOrDefault();
        }
    }
}
