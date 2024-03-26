using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.DataManager;
using FIFA_API.Models.Repository;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly IDataRepository<Categorie> dataRepository;

        public CategorieController(IDataRepository<Categorie> context)
        {
            dataRepository = context;
        }

        // GET: api/Categorie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategorie()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Categorie/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Categorie>> GetCategorieById(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }
            return categorie;
        }

        // GET: api/Categorie/Chaussette
        [HttpGet]
        [Route("[action]/{nom}")]
        [ActionName("GetByNom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Categorie>> GetCategorieByNom(string nom)
        {
            var categorie = await dataRepository.GetByStringAsync(nom);
            if (categorie == null)
            {
                return NotFound();
            }
            return categorie;
        }

        // PUT: api/Categorie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
        {
            if (id != categorie.CategorieId)
            {
                return BadRequest();
            }
            var catToUpdate = await dataRepository.GetByIdAsync(id);
            if (catToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(catToUpdate.Value, categorie);
                return NoContent();
            }
        }

        // POST: api/Categorie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(categorie);
            return CreatedAtAction("GetById", new { id = categorie.CategorieId }, categorie);
        }

        // DELETE: api/Categorie/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(categorie.Value);
            return NoContent();
        }

        /*private bool CategorieExists(int id)
        {
            return (dataRepository.Categorie?.Any(e => e.CategorieId == id)).GetValueOrDefault();
        }*/
    }
}
