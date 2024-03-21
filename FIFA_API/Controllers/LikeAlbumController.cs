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
    public class LikeAlbumController : ControllerBase
    {
        private readonly IDataRepository<LikeAlbum> dataRepository;

        public LikeAlbumController(IDataRepository<LikeAlbum> context)
        {
            dataRepository = context;
        }

        // GET: api/LikeAlbum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeAlbum>>> GetLikeAlbum()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/LikeAlbum/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LikeAlbum>> GetLikeAlbumById(int id)
        {
            var album = await dataRepository.GetByIdAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/LikeAlbum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLikeAlbum(int id, LikeAlbum likeAlbum)
        {
            if (id != likeAlbum.AlbumId)
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
                await dataRepository.UpdateAsync(albToUpdate.Value, likeAlbum);
                return NoContent();
            }
        }

        // POST: api/LikeAlbum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LikeAlbum>> PostLikeAlbum(LikeAlbum likeAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(likeAlbum);
            return CreatedAtAction("GetById", new { id = likeAlbum.AlbumId }, likeAlbum);
        }

        // DELETE: api/LikeAlbum/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLikeAlbum(int id)
        {
            var likeAlbum = await dataRepository.GetByIdAsync(id);
            if (likeAlbum == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(likeAlbum.Value);
            return NoContent();
        }

        //private bool LikeAlbumExists(int id)
        //{
        //    return (dataRepository.LikeAlbum?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        //}
    }
}
