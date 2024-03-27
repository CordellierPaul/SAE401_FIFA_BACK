using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorisController : ControllerBase
    {
        private readonly IColorisRepository dataRepository;

        public ColorisController(IColorisRepository context)
        {
            dataRepository = context;
        }

        // GET: api/Coloris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coloris>>> GetColoris()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Coloris/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Coloris>> GetColorisById(int id)
        {
            var coloris = await dataRepository.GetByIdAsync(id);

            if (coloris == null)
            {
                return NotFound();
            }
            return coloris;
        }

        // GET: api/Theme/4
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetColorisByProduitId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Coloris>>> GetColorisByProduitId(int id)
        {
            var coloris = await dataRepository.GetColorisProduit(id);

            if (coloris == null)
            {
                return NotFound();
            }

            return coloris;
        }

        // PUT: api/Coloris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutColoris(int id, Coloris coloris)
        {
            if (id != coloris.ColorisId)
            {
                return BadRequest();
            }
            var colToUpdate = await dataRepository.GetByIdAsync(id);
            if (colToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(colToUpdate.Value, coloris);
                return NoContent();
            }
        }

        // POST: api/Coloris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Coloris>> PostColoris(Coloris coloris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(coloris);

            return CreatedAtAction("GetById", new { id = coloris.ColorisId }, coloris);
        }

        // DELETE: api/Coloris/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteColoris(int id)
        {
            var coloris = await dataRepository.GetByIdAsync(id);
            if (coloris == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(coloris.Value);
            return NoContent();
        }

    }
}
