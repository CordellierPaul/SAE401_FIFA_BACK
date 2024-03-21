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
    public class AlbumController : ControllerBase
    {
        private readonly IDataRepository<Album> dataRepository;

        public AlbumController(IDataRepository<Album> context)
        {
            dataRepository = context;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbum()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Album/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Album>> GetAlbumById(int id)
        {
            var album = await dataRepository.GetByIdAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumId)
            {
                return BadRequest();
            }
            var albToUpdate = await dataRepository.GetByIdAsync(id);
            if (albToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(albToUpdate.Value, album);
                return NoContent();
            }
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(album);
            return CreatedAtAction("GetById", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await dataRepository.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(album.Value);
            return NoContent();
        }

        /*private bool AlbumExists(int id)
        {
            return (dataRepository.Album?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }*/
    }
}
