using Microsoft.AspNetCore.Mvc;
using Progetto.Models;
using Progetto.Services;

namespace Progetto.Controllers
{
    public class ImpiegatoController : Controller
    {
        #region service
        readonly ImpiegatoService service;

        public ImpiegatoController(ImpiegatoService service)
        {
            this.service = service;
        }
        #endregion

        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvataggio(Impiegato impiegato)
        {
            if (service.Insert(impiegato))
                return Redirect("/Impiegato/Index");

            return Redirect("/Impiegato/Error");
        }
    }
}
