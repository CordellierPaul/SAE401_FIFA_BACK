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
    public class ArticleJoueurController : ControllerBase
    {
        private readonly IDataRepository2clues<ArticleJoueur> dataRepository;

        public ArticleJoueurController(IDataRepository2clues<ArticleJoueur> context)
        {
            dataRepository = context;
        }

        // GET: api/ArticleJoueur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleJoueur>>> GetArticleJoueur()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ArticleJoueur/5
        [HttpGet]
        [Route("[action]/{articleId}/{joueurId}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArticleJoueur>> GetArticleJoueur(int articleId, int joueurId)
        {
            var articleJoueur = await dataRepository.GetByIdAsync(articleId, joueurId);

            if (articleJoueur == null)
            {
                return NotFound();
            }

            return articleJoueur;
        }

        // PUT: api/ArticleJoueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{articleId}/{joueurId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutArticleJoueur(int articleId, int joueurId, ArticleJoueur articleJoueur)
        {
            if (articleId != articleJoueur.ArticleId || joueurId != articleJoueur.JoueurId)
            {
                return BadRequest();
            }

            var labToUpdate = await dataRepository.GetByIdAsync(articleId, joueurId);

            if (labToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(labToUpdate.Value, articleJoueur);
                return NoContent();
            }
        }

        // POST: api/ArticleJoueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{articleId}/{joueurId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ArticleJoueur>> PostArticleJoueur(int articleId, int joueurId, ArticleJoueur articleJoueur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            articleJoueur.ArticleId = articleId;
            articleJoueur.JoueurId = joueurId;

            await dataRepository.AddAsync(articleJoueur);

            return CreatedAtAction("GetById", new { articleId, joueurId }, articleJoueur);
        }

        // DELETE: api/ArticleJoueur/5

        [HttpDelete("{articleId}/{joueurId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleJoueur(int articleId, int joueurId)
        {
            var articleJoueur = await dataRepository.GetByIdAsync(articleId, joueurId);
            if (articleJoueur == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(articleJoueur.Value);
            return NoContent();
        }

        //private bool ArticleJoueurExists(int id)
        //{
        //    return (dataRepository.ArticleJoueur?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        //}
    }
}
