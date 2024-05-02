using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Progetto_Chat.DTO;
using Progetto_Chat.Services;
using Progetto_Chat.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Progetto_Chat.Controllers
{
    [ApiController]
    [Route("api/utente")]
    public class UtenteController : Controller
    {
        #region service
        readonly UtenteService service;

        public UtenteController(UtenteService service)
        {
            this.service = service;
        }
        #endregion

        [HttpPost]
        public IActionResult Register(UtenteDTO utente)
        {
            if (ModelState.IsValid)
            {
                if (service.Register(utente))
                {
                    return Ok(new Status()
                    {
                        Stato = "SUCCESS",
                        Data = true
                    });
                }
            }

            return BadRequest();
        }

        [HttpDelete("{email}/{password}")]
        public IActionResult Delete(string email, string password)
        {
            if (!email.Trim().Equals("") && !password.Equals(""))
            {
                if (service.Delete(new UtenteDTO() { Post = email, Password = password}))
                    return Ok(new Status()
                    {
                        Stato = "SUCCESS",
                        Data = true
                    });
            }

            return BadRequest();
        }

        [HttpGet("{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            if (!email.Trim().Equals("") && !password.Equals(""))
            {
                string nickname = service.Login(new UtenteDTO() { Post = email, Password = password });

                if (!nickname.Equals(""))
                {
                    return Ok(new Status()
                    {
                        Stato = "SUCCESS",
                        Data = nickname
                    });
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UtenteDTO utente)
        {
            if (ModelState.IsValid)
                return Ok(new Status()
                {
                    Stato = "SUCCESS",
                    Data = service.Update(utente)
                });

            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Loggati(UtenteDTO objLogin)
        {

            if (objLogin.Post is not null && !service.Login(objLogin).Equals(""))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Post),
                    new Claim("UserType", "user"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Chat",
                    audience: "Utenti",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) , nickname = service.Login(objLogin) });
            }

            return Unauthorized();
        }
    }
}
