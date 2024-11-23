using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAutorizado");
            }

            ViewBag.Listado = miSistema.Publicaciones; // Guardo en la ViewBag la lista de Publicaciones que tiene el sistema
            return View();
        }
    }
}
