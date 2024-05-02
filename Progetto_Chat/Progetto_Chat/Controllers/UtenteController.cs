using Microsoft.AspNetCore.Mvc;
using Progetto_Chat.DTO;
using Progetto_Chat.Services;
using Progetto_Chat.Utils;

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
    }
}
