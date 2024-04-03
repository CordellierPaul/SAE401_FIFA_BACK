using Microsoft.AspNetCore.Mvc;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using FIFA_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Utilisateur)]
    public class InfosBancairesController : ControllerBase
    {
        private readonly IInfosBancairesRepository dataRepository;

        public InfosBancairesController(IInfosBancairesRepository context)
        {
            dataRepository = context;
        }

        // GET: api/InfosBancaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancaires()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/InfosBancaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancairesOfCompte()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/InfosBancaires/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InfosBancaires>> GetInfosBancairesById(int id)
        {
            var categorie = await dataRepository.GetByIdAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }
            return categorie;
        }

        // PUT: api/InfosBancaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutInfosBancaires(int id, InfosBancaires infosBancaires)
        {
            if (id != infosBancaires.InfosBancairesId)
            {
                return BadRequest();
            }
            var ibToUpdate = await dataRepository.GetByIdAsync(id);
            if (ibToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(ibToUpdate.Value, infosBancaires);
                return NoContent();
            }
        }

        // POST: api/InfosBancaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InfosBancaires>> PostInfosBancaires(InfosBancaires infosBancaires)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(infosBancaires);
            return CreatedAtAction("GetbyId", new { id = infosBancaires.InfosBancairesId }, infosBancaires);
        }

        // DELETE: api/InfosBancaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfosBancaires(int id)
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
