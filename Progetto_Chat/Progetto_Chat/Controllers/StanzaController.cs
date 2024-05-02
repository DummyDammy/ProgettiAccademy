using Microsoft.AspNetCore.Mvc;
using Progetto_Chat.DTO;
using Progetto_Chat.Services;
using Progetto_Chat.Utils;

namespace Progetto_Chat.Controllers
{
    [ApiController]
    [Route("api/stanza")]
    public class StanzaController : Controller
    {
        #region service
        readonly StanzaService service;

        public StanzaController(StanzaService service)
        {
            this.service = service;
        }
        #endregion

        [HttpGet("{nickname}")]
        public IActionResult GetAll(string nickname)
        {

        }

        [HttpPost("create")]
        public IActionResult Insert(StanzaDTO stanza)
        {
            if (ModelState.IsValid)
                if(stanza.Admin is not null)
                    if (stanza.Admin.Nick is not null)
                        if (!stanza.Title.Trim().Equals("") && !stanza.Admin.Nick.Trim().Equals(""))
                            return Ok(new Status()
                            {
                                Stato = "SUCCESS",
                                Data = service.Insert(stanza)
                            });

            return BadRequest();
        }

        [HttpDelete("{titolo}")]
        public IActionResult Delete(string titolo)
        {
            if (!titolo.Trim().Equals(""))
                return Ok(new Status()
                {
                    Stato = "SUCCESS",
                    Data = service.Delete(new StanzaDTO() { Title = titolo })
                });

            return BadRequest();
        }

        [HttpPut("add/{nickname}")]
        public IActionResult AddMember(StanzaDTO stanza, string nickname)
        {
            if (!nickname.Trim().Equals(""))
                return Ok(new Status()
                {
                    Stato = "SUCCESS",
                    Data = service.AddMemberToRoom(stanza, new UtenteDTO() { Nick = nickname })
                });

            return BadRequest();
        }

        [HttpPut("remove/{nickname}")]
        public IActionResult RemoveMemeber(StanzaDTO stanza, string nickname)
        {
            if (!nickname.Trim().Equals(""))
                return Ok(new Status()
                {
                    Stato = "SUCCESS",
                    Data = service.RemoveMemberFromRoom(stanza, new UtenteDTO() { Nick = nickname })
                });

            return BadRequest();
        }
    }
}
