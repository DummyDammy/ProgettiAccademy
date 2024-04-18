using C_.DTO;
using C_.Services;
using C_.Utils;
using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers
{
    [ApiController]
    [Route("giocatore")]
    public class GiocatoreController : Controller
    {
        #region service
        readonly GiocatoreService service;

        public GiocatoreController(GiocatoreService service)
        {
            this.service = service;
        }
        #endregion

        #region requests
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAll()
            });
        }

        [HttpPost]
        public IActionResult Insert(GiocatoreDTO giocatore)
        {
            if (giocatore.Name.Trim().Equals("") || giocatore.Color.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Riempire i campi"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(giocatore)
            });
        }

        [HttpDelete("{colore}")]
        public IActionResult Delete(string colore)
        {
            if (colore.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo colore è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Delete(new GiocatoreDTO() { Color = colore })
            });
        }

        [HttpPut("update")]
        public IActionResult Update(GiocatoreDTO giocatore)
        {
            if (giocatore.Color.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo colore è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(giocatore)
            });
        }

        [HttpGet("{colore}")]
        public IActionResult GetByColore(string colore)
        {
            if (colore.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo colore è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetByColor(new GiocatoreDTO() { Color = colore })
            });
        }

        [HttpGet("personaggi")]
        public IActionResult GetAllGetGiocatori()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAllGetPersonaggi()
            });
        }

        [HttpGet("{colore}/{nome}")]
        public IActionResult assignPersonaggio(string colore, string nome)
        {
            if (colore.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo colore è vuoto"
                });

            if (nome.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo nome è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.assignPersonaggio(new GiocatoreDTO() { Color = colore }, new PersonaggioDTO() { Name = nome })
            });
        }

        [HttpDelete("{colore}/{nome}")]
        public IActionResult DeleteCharacterFromTeam(string colore, string nome)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.DeleteCharacterFromTeam(new GiocatoreDTO() { Color = colore }, new PersonaggioDTO() { Name = nome })
            });
        }
        #endregion
    }
}
