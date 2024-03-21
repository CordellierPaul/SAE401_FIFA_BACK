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
    public class MediaController : ControllerBase
    {
        private readonly IDataRepository<Media> dataRepository;

        public MediaController(IDataRepository<Media> context)
        {
            dataRepository = context;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Media/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Media>> GetMediaById(int id)
        {
            var media = await dataRepository.GetByIdAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            return media;
        }

        // PUT: api/Media/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutMedia(int id, Media media)
        {
            if (id != media.MediaId)
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
                await dataRepository.UpdateAsync(medToUpdate.Value, media);
                return NoContent();
            }
        }

        // POST: api/Media
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Media>> PostMedia(Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(media);
            return CreatedAtAction("GetById", new { id = media.MediaId }, media);

        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            var media = await dataRepository.GetByIdAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(media.Value);

            return NoContent();
        }

        //private bool MediaExists(int id)
        //{
        //    return (dataRepository.Media?.Any(e => e.MediaId == id)).GetValueOrDefault();
        //}
    }
}
