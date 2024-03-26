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
    public class BlogImageController : ControllerBase
    {
        private readonly IDataRepository2clues<BlogImage> dataRepository;

        public BlogImageController(IDataRepository2clues<BlogImage> context)
        {
            dataRepository = context;
        }

        // GET: api/BlogImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogImage>>> GetBlogImage()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/BlogImage/5
        [HttpGet]
        [Route("[action]/{blogid}/{imageid}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlogImage>> GetBlogImage(int blogId, int imageId)
        {
            var likeBlog = await dataRepository.GetByIdAsync(blogId, imageId);

            if (likeBlog == null)
            {
                return NotFound();
            }

            return likeBlog;
        }

        // PUT: api/BlogImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{blogId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutBlogImage(int blogId, int imageId, BlogImage blogImage)
        {
            if (blogId != blogImage.BlogId || imageId != blogImage.ImageId)
            {
                return BadRequest();
            }

            var labToUpdate = await dataRepository.GetByIdAsync(blogId, imageId);

            if (labToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(labToUpdate.Value, blogImage);
                return NoContent();
            }
        }

        // POST: api/BlogImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{blogId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogImage>> PostBlogImage(int blogId, int imageId, BlogImage blogImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            blogImage.BlogId = blogId;
            blogImage.ImageId = imageId;

            await dataRepository.AddAsync(blogImage);

            return CreatedAtAction("GetById", new { blogId, imageId }, blogImage);
        }


        // DELETE: api/BlogImage/5
        [HttpDelete("{blogId}/{imageId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBlogImage(int blogId, int imageId)
        {
            var likeAlbum = await dataRepository.GetByIdAsync(blogId, imageId);
            if (likeAlbum == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(likeAlbum.Value);
            return NoContent();
        }
    }
}

