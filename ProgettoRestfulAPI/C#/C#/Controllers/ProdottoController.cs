using C_.Models;
using C_.Repository;
using Microsoft.AspNetCore.Mvc;

namespace C_.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProdottoRepository.GetInstance().GetAll());
        }

        [HttpPost]
        public IActionResult Insert(Prodotto prodotto)
        {
            if (ProdottoRepository.GetInstance().Insert(prodotto))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{codice}")]
        public IActionResult Delete(string codice)
        {
            if (ProdottoRepository.GetInstance().DeleteByCodice(codice))
                return Ok();

            return BadRequest();
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            return Ok(ProdottoRepository.GetInstance().GetByCodice(codice));
        }

        [HttpPatch]
        public IActionResult Update(Prodotto prodotto)
        {
            if (ProdottoRepository.GetInstance().Update(prodotto))
                return Ok();

            return BadRequest();
        }

    }
}
