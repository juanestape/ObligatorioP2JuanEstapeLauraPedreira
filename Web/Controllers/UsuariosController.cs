using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        Sistema miSistema = Sistema.Instancia; // Referencia a la instancia del Singleton

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasena)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("Debe ingresar un email");
                if (string.IsNullOrEmpty(contrasena)) throw new Exception("Debe ingresar una contraseña");
                Usuario usuario = miSistema.Login(email, contrasena); // Guardo en la variable usuario, la variable de tipo Usuario que me devuelva el método Login
                if (usuario == null) throw new Exception("Email o contraseña incorrecta"); // Verifico si el usuario es nulo por si el método Login no lo encontró
                HttpContext.Session.SetString("email", email); // Guardamos email en una variable de sesión para que estén vivas desde el momento de guardarlas en código, hasta que borremos la sesión o que se cumpla un time out que tiene la sesión
                HttpContext.Session.SetString("rol", usuario.Rol()); // Invoco el método Rol para guardarme el string que me retorna, en la variable rol

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Método para que el usuario cliente pueda Cargar saldo en su billetera electrónica
        // Agregarle condicional para rol y que muestre esta vista sólo para cliente, si no está autorizado va a otra vista de no autorizado en carpeta shared.
    }
}
