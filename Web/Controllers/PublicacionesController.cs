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
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente") // Condicional para que sólo pueda entrar a la url el usuario logueado con el rol que corresponde
            {
                return View("NoAutorizado");
            }
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            if (TempData["Error"] != null) ViewBag.Exito = TempData["Error"];

            ViewBag.Listado = miSistema.Publicaciones; // Guardo en la ViewBag la lista de Publicaciones que tiene el sistema
            return View();
        }

        [HttpGet]
        public IActionResult RealizarOferta(int id)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAutorizado");
            }

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult RealizarOferta(int id, int nuevaOferta)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAutorizado");
            }

            try
            {
                if (id < 0) throw new Exception("El Id de la Publicación no es válido");
                if (nuevaOferta < 0) throw new Exception("La Nueva Oferta no puede ser negativa");
                miSistema.AltaOferta(); // FALTA PASARLE LA NUEVA OFERTA
                TempData["Exito"] = $"Se aceptó la nueva oferta: ${nuevaOferta}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Listado");
        }
    }
}
