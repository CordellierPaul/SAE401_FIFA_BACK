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
        private readonly IDataRepository2clues<LikeAlbum> dataRepository;

        public LikeAlbumController(IDataRepository2clues<LikeAlbum> context)
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
        [Route("[action]/{albumId}/{utilisateurId}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LikeAlbum>> GetLikeAlbumById(int albumId, int utilisateurId)
        {
            var likeAlbum = await dataRepository.GetByIdAsync(albumId, utilisateurId);

            if (likeAlbum == null)
            {
                return NotFound();
            }

            return likeAlbum;
        }


        // PUT: api/LikeAlbum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{albumId}/{utilisateurId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLikeAlbum(int albumId, int utilisateurId, LikeAlbum likeAlbum)
        {
            if (albumId != likeAlbum.AlbumId || utilisateurId != likeAlbum.UtilisateurId)
            {
                return BadRequest();
            }

            var labToUpdate = await dataRepository.GetByIdAsync(albumId, utilisateurId);

            if (labToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(labToUpdate.Value, likeAlbum);
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
        public async Task<IActionResult> DeleteLikeAlbum(int aid, int uid)
        {
            var likeAlbum = await dataRepository.GetByIdAsync(aid, uid);
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
