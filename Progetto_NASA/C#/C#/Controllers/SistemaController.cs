using C_.DTO;
using C_.Services;
using C_.Utils;
using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers
{
    [ApiController]
    [Route("api/sistema")]
    public class SistemaController : Controller
    {
        #region service
        readonly SistemaService service;

        public SistemaController(SistemaService service)
        {
            this.service = service;
        }
        #endregion

        #region Requests
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status ()
            {
                Stato = "SUCCESS",
                Data = service.GetAll()
            });
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            return Ok(new Status ()
            {
                Stato = "SUCCESS",
                Data = service.GetByCodice(new SistemaDTO() { Code = codice })
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult DeleteByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.DeleteByCodice(new SistemaDTO() { Code = codice })
            });
        }

        [HttpPost]
        public IActionResult Insert(SistemaDTO sistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(sistema)
            });
        }

        [HttpGet("corpi")]
        public IActionResult GetAllGetBodies()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAllGetBodies()
            });
        }

        [HttpGet("{codiceCorpo}/{codiceSistema}")]
        public IActionResult assignSistema(string codiceCorpo, string codiceSistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.assign(new CorpoDTO() { Code = codiceCorpo }, new SistemaDTO() { Code = codiceSistema })
            });
        }

        [HttpPost("update")]
        public IActionResult Update(SistemaDTO sistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(sistema)
            });
        }

        [HttpDelete("{codiceSistema}/{codiceCorpo}")]
        public IActionResult RemoveCorpoFromSistema(string codiceSistema, string codiceCorpo) 
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.RemoveSistemaFromCorpo(new SistemaDTO() { Code = codiceSistema }, new CorpoDTO { Code = codiceCorpo })
            });
        }
        #endregion
    }
}
