using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using Action = FIFA_API.Models.EntityFramework.Action;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ActionController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Action>>> GetAction()
        {
          if (_context.Action == null)
          {
              return NotFound();
          }
            return await _context.Action.ToListAsync();
        }

        // GET: api/Action/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Action>> GetAction(int id)
        {
          if (_context.Action == null)
          {
              return NotFound();
          }
            var action = await _context.Action.FindAsync(id);

            if (action == null)
            {
                return NotFound();
            }

            return action;
        }

        // PUT: api/Action/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAction(int id, Action action)
        {
            if (id != action.ActionId)
            {
                return BadRequest();
            }

            _context.Entry(action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionExists(id))
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

        // POST: api/Action
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Action>> PostAction(Action action)
        {
          if (_context.Action == null)
          {
              return Problem("Entity set 'FifaDbContext.Action'  is null.");
          }
            _context.Action.Add(action);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAction", new { id = action.ActionId }, action);
        }

        // DELETE: api/Action/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            if (_context.Action == null)
            {
                return NotFound();
            }
            var action = await _context.Action.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            _context.Action.Remove(action);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActionExists(int id)
        {
            return (_context.Action?.Any(e => e.ActionId == id)).GetValueOrDefault();
        }
    }
}
