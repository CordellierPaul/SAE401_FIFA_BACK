using FIFA_API.Models;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesCompteController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICompteRepository _dataRepository;

        public AccesCompteController(IConfiguration config, ICompteRepository dataRepository)
        {
            _config = config;
            _dataRepository = dataRepository;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Connexion([FromBody] Compte compte)
        {
            IActionResult response = Unauthorized();

            Compte? user = await _dataRepository.GetCompteByCompte(compte);

            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Inscription([FromBody] Compte compte)
        {
            if (compte.UtilisateurCompte is null)
                return BadRequest("Lorsqu'un compte est créé, il doit contenir les informations sur l'utilisateur");

            await _dataRepository.AddAsync(compte);

            string tokenString = GenerateJwtToken(compte);

            return Ok(new { token = tokenString, userDetails = compte });
        }

        private string GenerateJwtToken(Compte compte)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            string role;

            if (compte.TypeCompte == 2)
                role = Policies.Admin;
            else
                role = Policies.Utilisateur;

            Console.WriteLine("\n\n\n" + compte.UtilisateurCompte?.UtilisateurId + "\n\n\n");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, compte.CompteEmail),
                new Claim("email", compte.CompteEmail),
                new Claim("role", role),
                new Claim("idcompte", compte.CompteId.ToString()),
                new Claim("idutilisateur", compte.UtilisateurCompte?.UtilisateurId.ToString() ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
