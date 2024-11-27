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
            if (TempData["ExitoCompra"] != null) ViewBag.ExitoCompra = TempData["ExitoCompra"];
            if (TempData["ErrorCompra"] != null) ViewBag.ErrorCompra = TempData["ErrorCompra"];

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
                if (nuevaOferta <= 0) throw new Exception("La nueva oferta no puede ser negativa, ni 0");

                int idUsuario = miSistema.ObtenerIdUsuarioPorEmail(HttpContext.Session.GetString("email"));
                miSistema.AgregaroOfertaASubasta(id, idUsuario, nuevaOferta, DateTime.Now);
                TempData["Exito"] = $"Se aceptó la nueva oferta: ${nuevaOferta}";
                return RedirectToAction("Listado");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Id = id;
                return View();
            }
        }

        public IActionResult FinalizarVenta(int id)
        {
            try
            {
                if (id < 0) throw new Exception("El Id de la Publicación no es válido");
                int idUsuario = miSistema.ObtenerIdUsuarioPorEmail(HttpContext.Session.GetString("email"));

                TempData["ExitoCompra"] = "La compra se realizó correctamente";
                miSistema.CerrarPublicacion(idUsuario, id);
            }
            catch (Exception ex)
            {
                TempData["ErrorCompra"] = ex.Message;

            }
            return RedirectToAction("Listado");
        }


        [HttpGet]
        public IActionResult ListadoSubastas()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Administrador")
            {
                return View("NoAutorizado");
            }
            ViewBag.Listado = miSistema.PublicacionesOrdenadasPorFecha();
            return View();
        }


        public IActionResult FinalizarSubasta(int id)
        {
            try
            {
                if (id < 0) throw new Exception("El Id de la Publicación no es válido");
                int idUsuario = miSistema.ObtenerIdUsuarioPorEmail(HttpContext.Session.GetString("email"));

                TempData["ExitoCompra"] = "La compra se realizó correctamente";
                miSistema.CerrarPublicacion(idUsuario, id);
            }
            catch (Exception ex)
            {
                TempData["ErrorCompra"] = ex.Message;

            }
            return RedirectToAction("ListadoSubastas");
        }
    }
}
