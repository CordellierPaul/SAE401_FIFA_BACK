using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using Action = FIFA_API.Models.EntityFramework.Action;
using FIFA_API.Models.Repository;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IDataRepository<Action> dataRepository;

        public ActionController(IDataRepository<Action> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/Action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Action>>> GetAllAction()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Action/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Action>> GetActionById(int id)
        {
            var action = await dataRepository.GetByIdAsync(id);

            if (action == null)
            {
                return NotFound();
            }
            return action;
        }

        // PUT: api/Action/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAction(int id, Action action)
        {
            if (id != action.ActionId)
            {
                return BadRequest();
            }
            var actToUpdate = await dataRepository.GetByIdAsync(id);
            if (actToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(actToUpdate.Value, action);
                return NoContent();
            }
        }

        // POST: api/Action
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Action>> PostAction(Action action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(action);
            return CreatedAtAction("GetById", new { id = action.ActionId }, action);
        }

        // DELETE: api/Action/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var action = await dataRepository.GetByIdAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(action.Value);
            return NoContent();
        }

        /*private bool ActionExists(int id)
        {
            return (dataRepository.Action?.Any(e => e.ActionId == id)).GetValueOrDefault();
        }*/
    }
}
