﻿using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesCompteController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IDataRepository<Compte> _dataRepository;


        // Code sql pour ajouter un compte test :
        // insert into t_e_compte_cpt (cpt_email, cpt_mdp, cpt_login, cpt_typecompte)
        // values ('emdzdal@testt.com', 'qicxsgllezjmejtxvnauzwunivwcgdrxzfgvxqybeihuxgkzeeflsqfjfpbncubyojxjtrgfjeyxjmwgdcgqxsrhbusbpfrdewyhvgfrjwktqvnnybgtqxjshfjrheud', 'logind_ffe', 1)

        // Code à ajouter dans Body de postman (en raw) pour tester :
        //{
        //    "compteEmail": "emdzdal@testt.com",
        //    "compteMdp": "qicxsgllezjmejtxvnauzwunivwcgdrxzfgvxqybeihuxgkzeeflsqfjfpbncubyojxjtrgfjeyxjmwgdcgqxsrhbusbpfrdewyhvgfrjwktqvnnybgtqxjshfjrheud"
        //}

        public AccesCompteController(IConfiguration config, IDataRepository<Compte> dataRepository)
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

            Compte? user = await AuthenticateUser(compte);

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

            compte.UtilisateurCompte = null;

            string tokenString = GenerateJwtToken(compte);

            await _dataRepository.AddAsync(compte);

            return Ok(new { token = tokenString, userDetails = compte });
        }

        private async Task<Compte?> AuthenticateUser(Compte user)
        {
            var response = await _dataRepository.GetAllAsync();

            if (response == null || response.Value == null)
                return null;

            return response.Value.SingleOrDefault(x => x.CompteEmail.ToUpper() == user.CompteEmail.ToUpper() && x.CompteMdp == user.CompteMdp);
        }

        private string GenerateJwtToken(Compte userInfo)
        {
            var securityKey = new
           SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("email", userInfo.CompteEmail.ToString()),
                new Claim("type", userInfo.TypeCompte.ToString()),
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
