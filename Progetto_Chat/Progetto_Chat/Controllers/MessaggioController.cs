using Microsoft.AspNetCore.Mvc;
using Progetto_Chat.DTO;
using Progetto_Chat.Services;
using Progetto_Chat.Utils;

namespace Progetto_Chat.Controllers
{
    [ApiController]
    [Route("api/messaggio")]
    public class MessaggioController : Controller
    {
        #region service
        readonly MessaggioService service;

        public MessaggioController(MessaggioService service)
        {
            this.service = service;
        }
        #endregion

        [HttpPost("{nickname}/{titolo}")]
        public IActionResult Send(MessaggioDTO messaggio, string titolo, string nickname)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Send(messaggio, new StanzaDTO() { Title = titolo }, new UtenteDTO() { Nick = nickname })
            });
        }

        [HttpGet("{titolo}")]
        public IActionResult GetMessagesOfRoom(string titolo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetMessagesOfRoom(new StanzaDTO() { Title = titolo})
            });
        }
    }
}
