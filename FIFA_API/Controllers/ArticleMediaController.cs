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
    public class ArticleMediaController : ControllerBase
    {
        private readonly IDataRepository2clues<ArticleMedia> dataRepository;

        public ArticleMediaController(IDataRepository2clues<ArticleMedia> context)
        {
            dataRepository = context;
        }

        // GET: api/ArticleMedia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleMedia>>> GetArticleMedia()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ArticleMedia/5
        [HttpGet]
        [Route("[action]/{articleId}/{mediaId}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArticleMedia>> GetArticleMedia(int articleId, int mediaId)
        {
            var articleMedia = await dataRepository.GetByIdAsync(articleId, mediaId);

            if (articleMedia == null)
            {
                return NotFound();
            }

            return articleMedia;
        }

        // PUT: api/ArticleMedia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{articleId}/{mediaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutArticleMedia(int articleId, int mediaId, ArticleMedia articleMedia)
        {
            if (articleId != articleMedia.ArticleId || mediaId != articleMedia.MediaId)
            {
                return BadRequest();
            }

            var labToUpdate = await dataRepository.GetByIdAsync(articleId, mediaId);

            if (labToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(labToUpdate.Value, articleMedia);
                return NoContent();
            }
        }

        // POST: api/ArticleMedia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{articleId}/{mediaId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ArticleMedia>> PostArticleMedia(int articleId, int mediaId,  ArticleMedia articleMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            articleMedia.ArticleId = articleId;
            articleMedia.MediaId = mediaId;

            await dataRepository.AddAsync(articleMedia);

            return CreatedAtAction("GetById", new { articleId, mediaId }, articleMedia);
        }

        // DELETE: api/ArticleMedia/5
        [HttpDelete("{articleId}/{articleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleMedia(int articleId, int mediaId)
        {
            var articleMedia = await dataRepository.GetByIdAsync(articleId, mediaId);
            if (articleMedia == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(articleMedia.Value);
            return NoContent();
        }

        //private bool ArticleMediaExists(int id)
        //{
        //    return (dataRepository.ArticleMedia?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        //}
    }
}
