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
    public class AlbumImageController : ControllerBase
    {
        private readonly IDataRepository2clues<AlbumImage> dataRepository;

        public AlbumImageController(IDataRepository2clues<AlbumImage> context)
        {
            dataRepository = context;
        }

        // GET: api/AlbumImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumImage>>> GetAlbumImage()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/AlbumImage/5
        [HttpGet]
        [Route("[action]/{albumId}/{imageid}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlbumImage>> GetAlbumImage(int albumId, int imageId)
        {
            var albumImage = await dataRepository.GetByIdAsync(albumId, imageId);

            if (albumImage == null)
            {
                return NotFound();
            }

            return albumImage;
        }

        // PUT: api/AlbumImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{albumId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAlbumImage(int albumId, int imageId, AlbumImage albumImage)
        {
            if (albumId != albumImage.AlbumId || imageId != albumImage.ImageId)
            {
                return BadRequest();
            }

            var aliToUpdate = await dataRepository.GetByIdAsync(albumId, imageId);

            if (aliToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(aliToUpdate.Value, albumImage);
                return NoContent();
            }
        }

        // POST: api/AlbumImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{albumId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AlbumImage>> PostAlbumImage(int albumId, int imageId, AlbumImage albumImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            albumImage.AlbumId = albumId;
            albumImage.ImageId = imageId;

            await dataRepository.AddAsync(albumImage);

            return CreatedAtAction("GetById", new { albumId, imageId }, albumImage);
        }

        // DELETE: api/AlbumImage/5
        [HttpDelete("{albumId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAlbumImage(int albumId, int imageId)
        {
            var albumImage = await dataRepository.GetByIdAsync(albumId, imageId);
            if (albumImage == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(albumImage.Value);
            return NoContent();
        }

        //private bool AlbumImageExists(int id)
        //{
        //    return (dataRepository.AlbumImage?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        //}
    }
}
