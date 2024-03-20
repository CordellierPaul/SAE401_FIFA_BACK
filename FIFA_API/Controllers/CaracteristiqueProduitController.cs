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
    public class CaracteristiqueProduitController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public CaracteristiqueProduitController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/CaracteristiqueProduit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaracteristiqueProduit>>> GetCaracteristiqueProduit()
        {
          if (_context.CaracteristiqueProduit == null)
          {
              return NotFound();
          }
            return await _context.CaracteristiqueProduit.ToListAsync();
        }

        // GET: api/CaracteristiqueProduit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaracteristiqueProduit>> GetCaracteristiqueProduit(int id)
        {
          if (_context.CaracteristiqueProduit == null)
          {
              return NotFound();
          }
            var caracteristiqueProduit = await _context.CaracteristiqueProduit.FindAsync(id);

            if (caracteristiqueProduit == null)
            {
                return NotFound();
            }

            return caracteristiqueProduit;
        }

        // PUT: api/CaracteristiqueProduit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristiqueProduit(int id, CaracteristiqueProduit caracteristiqueProduit)
        {
            if (id != caracteristiqueProduit.CaracteristiqueId)
            {
                return BadRequest();
            }

            _context.Entry(caracteristiqueProduit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristiqueProduitExists(id))
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

        // POST: api/CaracteristiqueProduit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaracteristiqueProduit>> PostCaracteristiqueProduit(CaracteristiqueProduit caracteristiqueProduit)
        {
          if (_context.CaracteristiqueProduit == null)
          {
              return Problem("Entity set 'FifaDbContext.CaracteristiqueProduit'  is null.");
          }
            _context.CaracteristiqueProduit.Add(caracteristiqueProduit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaracteristiqueProduitExists(caracteristiqueProduit.CaracteristiqueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaracteristiqueProduit", new { id = caracteristiqueProduit.CaracteristiqueId }, caracteristiqueProduit);
        }

        // DELETE: api/CaracteristiqueProduit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristiqueProduit(int id)
        {
            if (_context.CaracteristiqueProduit == null)
            {
                return NotFound();
            }
            var caracteristiqueProduit = await _context.CaracteristiqueProduit.FindAsync(id);
            if (caracteristiqueProduit == null)
            {
                return NotFound();
            }

            _context.CaracteristiqueProduit.Remove(caracteristiqueProduit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaracteristiqueProduitExists(int id)
        {
            return (_context.CaracteristiqueProduit?.Any(e => e.CaracteristiqueId == id)).GetValueOrDefault();
        }
    }
}
