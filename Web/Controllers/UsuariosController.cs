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
            if (TempData["Exito"] != null) ViewBag.ExitoRegistro = TempData["Exito"]; // Consultamos si hay algo guardado en TempData["Exito"] y si es así lo guardo en una ViewBag para mostrarlo en pantalla
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

        [HttpGet]
        public IActionResult Registro() 
        {
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Registro(Cliente usuarioCliente)
        {
            try 
            {
                // Como usamos model binding no sería necesario validar los atributos de usuarios, porque no estaríamos aprovechando el beneficio del MB al tener que separarlos, pero igual lo haremos
                if (string.IsNullOrEmpty(usuarioCliente.Nombre)) throw new Exception("El Nombre no puede ser vacío");
                if (string.IsNullOrEmpty(usuarioCliente.Apellido)) throw new Exception("El Apellido no puede ser vacío");
                if (string.IsNullOrEmpty(usuarioCliente.Email)) throw new Exception("El Email no puede ser vacío");
                if (string.IsNullOrEmpty(usuarioCliente.Contrasenia)) throw new Exception("La Contraseña no puede ser vacía");

                miSistema.AltaUsuarios(usuarioCliente);
                TempData["Exito"] = $"Usuario {usuarioCliente.Nombre} registrado correctamente"; // TempData sobrevive a una petición, la seteamos acá y la usamos cuando redireccione a Login
                return RedirectToAction("Login"); // Redireccionamos la petición a la acción Login para que haga el método y retorne la vista
            }
            catch (Exception ex) { 
                ViewBag.Error = ex.Message;
                return View(usuarioCliente); // Retornamos la vista de Registro con el objeto guardado con los datos que ingresó en el formulario, para que no tenga que volver a completarlos
            }
        }



        // Método para que el usuario cliente pueda Cargar saldo en su billetera electrónica
        // Agregarle condicional para rol y que muestre esta vista sólo para cliente, si no está autorizado va a otra vista de no autorizado en carpeta shared.
    }
}
