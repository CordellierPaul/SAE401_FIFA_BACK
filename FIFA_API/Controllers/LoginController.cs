using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private List<Compte> appUsers = new List<Compte>
        {
            new Compte { CompteEmail = "ezf@fzefde.com", CompteMdp = "1234", TypeCompte = 1 },
            new Compte { CompteEmail = "test@fzefeffde.com", CompteMdp = "12345", TypeCompte = 3 }
        };

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Compte login)
        {
            IActionResult response = Unauthorized();
            Compte? user = AuthenticateUser(login);
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
        private Compte? AuthenticateUser(Compte user)
        {
            return appUsers.SingleOrDefault(x => x.CompteEmail.ToUpper() == user.CompteEmail.ToUpper() && x.CompteMdp == user.CompteMdp);
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
