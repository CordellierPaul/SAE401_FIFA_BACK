using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Rewrite;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitRepository dataRepository;

        public ProduitController(IProduitRepository context)
        {
            dataRepository = context;
        }

        // GET: api/Produit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduit()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Produit/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produit>> GetProduitById(int id)
        {
            ActionResult<Produit> produit = await dataRepository.GetByIdAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit!;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetAnImageOfProduitById")]
        public async Task<ActionResult<string>> GetAnImageOfProduitById(int id)
        {
            var result = await dataRepository.GetAnImagePathOfProduitById(id);

            if (result is null || result.Value is null)
                return NotFound();

            return result.Value;
        }

        [HttpGet]
        [Route("[action]/{searchInput}")]
        [ActionName("GetSearchResults")]
        public async Task<ActionResult<IEnumerable<Produit>>> GetSearchResults(string searchInput)
        {
            return await dataRepository.GetSearchResults(searchInput);
        }


        // PUT: api/Produit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.ProduitId)
            {
                return BadRequest();
            }
            var pdtToUpdate = await dataRepository.GetByIdAsync(id);
            if (pdtToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(pdtToUpdate.Value, produit);
                return NoContent();
            }
        }

        // POST: api/Produit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(produit);

            return CreatedAtAction("GetProduit", new { id = produit.ProduitId }, produit);
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(produit.Value);
            return NoContent();
        }

        /*private bool ProduitExists(int id)
        {
            return (dataRepository.Produit?.Any(e => e.ProduitId == id)).GetValueOrDefault();
        }*/
    }
}
