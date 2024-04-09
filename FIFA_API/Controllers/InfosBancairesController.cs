using Microsoft.AspNetCore.Mvc;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using FIFA_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        // GET: api/GetInfosBancairesOfUser
        [HttpGet]
        [Route("[action]/{userId}")]
        [ActionName("GetInfosBancairesOfUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancairesOfUser(int userId)
        {
            if (!TokenIsValid(userId))
            {
                return Unauthorized();
            }

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
            var infoBancaireResult = await dataRepository.GetByIdAsync(id);

            if (infoBancaireResult is null || infoBancaireResult.Value is null)
            {
                return NotFound();
            }
            if (!TokenIsValid(id))
            {
                return Unauthorized();
            }
            return infoBancaireResult;
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
            if (!TokenIsValid(infosBancaires.UtilisateurId))
            {
                return Unauthorized();
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
                return BadRequest(ModelState);

            if (!TokenIsValid(infosBancaires.UtilisateurId))
                return Unauthorized();

            await dataRepository.AddAsync(infosBancaires);
            return CreatedAtAction("GetbyId", new { id = infosBancaires.InfosBancairesId }, infosBancaires);
        }

        // DELETE: api/InfosBancaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfosBancaires(int id)
        {
            var infosBancaires = await dataRepository.GetByIdAsync(id);

            if (infosBancaires is null || infosBancaires.Value is null)
                return NotFound();

            if (!TokenIsValid(infosBancaires.Value.UtilisateurId))
                return Unauthorized();

            await dataRepository.DeleteAsync(infosBancaires.Value);
            return NoContent();
        }


        private bool TokenIsValid(int utilisateurId)
        {
#if TESTENCOURS
            return true;
#else
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is null)
                return false;

            Claim? utilisateurIdClaim = identity.FindFirst("idutilisateur");

            if (utilisateurIdClaim is null)
                return false;

            return utilisateurIdClaim.Value == utilisateurId.ToString();
#endif
        }
    }
}
