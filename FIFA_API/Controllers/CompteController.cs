using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CompteController : ControllerBase
    {
        private readonly IDataRepository<Compte> dataRepository;

        public CompteController(IDataRepository<Compte> context)
        {
            dataRepository = context;
        }

        // GET: api/Compte/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            if (!TokenIsValid(id))
                return Unauthorized();

            var compte = await dataRepository.GetByIdAsync(id);

            if (compte == null)
            {
                return NotFound();
            }
            return compte;
        }


        // GET: api/Compte/toto@titi.fr
        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await dataRepository.GetByStringAsync(email);
            if (compte == null || compte.Value == null)
            {
                return NotFound();
            }

            return compte;
        }

        // PUT: api/Compte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            if (!TokenIsValid(id))
                return Unauthorized();

            var comToUpdate = await dataRepository.GetByIdAsync(id);
            if (comToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(comToUpdate.Value, compte);
                return NoContent();
            }
        }

        // POST: api/Compte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(compte);
            return CreatedAtAction("GetById", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            if (!TokenIsValid(id))
                return Unauthorized();

            var compte = await dataRepository.GetByIdAsync(id);
            if (compte == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(compte.Value);
            return NoContent();
        }


        // GET: api/EmailIsUnique
        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("EmailIsInDatabase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> EmailIsInDatabase(string email)
        {
            ActionResult<Compte>? actionResult = await dataRepository.GetByStringAsync(email);
            return actionResult.Value is not null;
        }

        private bool TokenIsValid(int compteId)
        {
#if TESTENCOURS
            return true;
#else
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is null)
                return false;

            Claim? compteIdClaim = identity.FindFirst("idcompte");

            if (compteIdClaim is null)
                return false;

            return compteIdClaim.Value == compteId.ToString();
#endif
        }
    }
}
