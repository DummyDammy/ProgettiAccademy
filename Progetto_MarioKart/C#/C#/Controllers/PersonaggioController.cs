using C_.DTO;
using C_.Services;
using C_.Utils;
using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers
{
    [ApiController]
    [Route("personaggio")]
    public class PersonaggioController : Controller
    {
        #region service
        readonly PersonaggioService service;

        public PersonaggioController(PersonaggioService service)
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
        public IActionResult Insert(PersonaggioDTO personaggio)
        {
            if (personaggio.Name.Trim().Equals("") || personaggio.Category.Trim().Equals("") || personaggio.Veichle.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Riempire i campi"
                });

            if (!personaggio.Veichle.Trim().Equals("Kart") || !personaggio.Veichle.Trim().Equals("Moto"))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "I mezzi possono essere solo Kart o Moto"
                });

            if (!personaggio.Category.Trim().Equals("50cc") || !personaggio.Category.Trim().Equals("100cc") || !personaggio.Category.Trim().Equals("150cc"))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Le categorie possono essere solo 50cc o 100cc o 150cc"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(personaggio)
            });
        }

        [HttpDelete("{nome}")]
        public IActionResult Delete(string nome)
        {
            if (nome.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo nome è vuoto"
                });


            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Delete(new PersonaggioDTO() { Name = nome })
            });
        }

        [HttpPost("update")]
        public IActionResult Update(PersonaggioDTO personaggio)
        {
            if (personaggio.Name.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo nome è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(personaggio)
            });
        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            if (nome.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo nome è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetByNome(new PersonaggioDTO() { Name = nome })
            });
        }

        [HttpGet("giocatori")]
        public IActionResult GetAllGetGiocatori()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAllGetGiocatori()
            });
        }

        [HttpGet("disponibili")]
        public IActionResult GetAvialable()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAvialable()
            });
        }

        [HttpGet("taken")]
        public IActionResult GetTaken()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetTaken()
            });
        }
        #endregion
    }
}
