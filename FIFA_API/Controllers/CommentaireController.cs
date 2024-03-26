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
    public class CommentaireController : ControllerBase
    {
        private readonly IDataRepositoryWithoutStr<Commentaire> dataRepository;

        public CommentaireController(IDataRepositoryWithoutStr<Commentaire> context)
        {
            dataRepository = context;
        }

        // GET: api/Command
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaire()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Command/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commentaire>> GetCommentaireById(int id)
        {
            var commentaire = await dataRepository.GetByIdAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }
            return commentaire;
        }

        // PUT: api/Command/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (id != commentaire.CommentaireId)
            {
                return BadRequest();
            }
            var commentaireToUpdate = await dataRepository.GetByIdAsync(id);
            if (commentaireToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(commentaireToUpdate.Value, commentaire);
                return NoContent();
            }
        }

        // POST: api/Command
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commentaire>> PostCommentaire(Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(commentaire);
            return CreatedAtAction("GetById", new { id = commentaire.CommentaireId }, commentaire);
        }

        // DELETE: api/Command/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(categorie.Value);
            return NoContent();
        }

    }
}
