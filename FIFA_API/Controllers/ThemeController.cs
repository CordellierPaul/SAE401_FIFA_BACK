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
    public class ThemeController : ControllerBase
    {
        private readonly IDataRepository<Theme> dataRepository;

        public ThemeController(IDataRepository<Theme> context)
        {
            dataRepository = context;
        }

        // GET: api/Theme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetTheme()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Theme/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Theme>> GetTheme(int id)
        {
            var theme = await dataRepository.GetByIdAsync(id);

            if (theme == null)
            {
                return NotFound();
            }

            return theme;
        }

        // PUT: api/Theme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTheme(int id, Theme theme)
        {
            if (id != theme.ThemeId)
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
                await dataRepository.UpdateAsync(actToUpdate.Value, theme);
                return NoContent();
            }
        }

        // POST: api/Theme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Theme>> PostTheme(Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(theme);
            return CreatedAtAction("GetById", new { id = theme.ThemeId }, theme);

        }

        // DELETE: api/Theme/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            var theme = await dataRepository.GetByIdAsync(id);
            if (theme == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(theme.Value);

            return NoContent();
        }

        //private bool ThemeExists(int id)
        //{
        //    return (dataRepository.Theme?.Any(e => e.ThemeId == id)).GetValueOrDefault();
        //}
    }
}
