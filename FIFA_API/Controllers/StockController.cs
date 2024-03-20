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
    public class StockController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public StockController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStock()
        {
          if (_context.Stock == null)
          {
              return NotFound();
          }
            return await _context.Stock.ToListAsync();
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
          if (_context.Stock == null)
          {
              return NotFound();
          }
            var stock = await _context.Stock.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.StockId)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
          if (_context.Stock == null)
          {
              return Problem("Entity set 'FifaDbContext.Stock'  is null.");
          }
            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.StockId }, stock);
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            if (_context.Stock == null)
            {
                return NotFound();
            }
            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return (_context.Stock?.Any(e => e.StockId == id)).GetValueOrDefault();
        }
    }
}
