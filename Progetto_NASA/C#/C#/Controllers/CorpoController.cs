using C_.DTO;
using C_.Services;
using C_.Utils;
using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers
{
    [ApiController]
    [Route("api/corpo")]
    public class CorpoController : Controller
    {
        #region service
        readonly CorpoService service;

        public CorpoController(CorpoService service)
        {
            this.service = service;
        }
        #endregion

        #region Requests
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAll()
            });
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetByCodice(new CorpoDTO() { Code = codice })
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult DeleteByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.DeleteByCodice(new CorpoDTO() { Code = codice })
            });
        }

        [HttpPost]
        public IActionResult Insert(CorpoDTO corpo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(corpo)
            });
        }

        [HttpGet("sistemi")]
        public IActionResult GetAllGetSystems()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAllGetSystems()
            });
        }

        [HttpGet("{codiceSistema}/{codiceCorpo}")]
        public IActionResult assignCorpo(string codiceSistema, string codiceCorpo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.assign(new SistemaDTO() { Code = codiceSistema } , new CorpoDTO() { Code = codiceCorpo })
            });
        }

        [HttpPost("update")]
        public IActionResult Update(CorpoDTO corpo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(corpo)
            });
        }

        [HttpDelete("{codiceCorpo}/{codiceSistema}")]
        public IActionResult RemoveCorpoFromSistema(string codiceCorpo, string codiceSistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.RemoveCorpoFromSistema(new CorpoDTO { Code = codiceCorpo }, new SistemaDTO() { Code = codiceSistema })
            });
        }
        #endregion
    }
}
