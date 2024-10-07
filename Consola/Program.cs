using System.Text.RegularExpressions;
using Dominio;

namespace Consola
{
    internal class Program
    {
        private static Sistema miSistema;
        static void Main(string[] args)
        {
            miSistema = new Sistema();
            string opcion = "";

            while (opcion != "0")
            {
                MostrarMenu();
                opcion = PedirPalabras("Ingrese una opcion -> ");

                switch (opcion)
                {
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        ListarArticulosDadaCategoria();
                        break;
                    case "3":
                        AltaArticulo();
                        break;
                    case "4":
                        ListarPublicacionesEntreFechas();
                        break;
                    case "5":
                        ListarPublicaciones();
                        break;
                    case "0":
                        Console.WriteLine("Salir ...");
                        break;
                    default:
                        MostrarError("Debe ingresar una opcion valida");
                        PressToContinue();
                        break;
                }
            }
        }

        #region METODOS DE MENU

        static void MostrarMenu()
        {
            Console.Clear();
            CambioDeColor("**************", ConsoleColor.Cyan);
            CambioDeColor("     MENU     ", ConsoleColor.Cyan);
            CambioDeColor("**************", ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine("1 - Listado de Clientes");
            Console.WriteLine("2 - Listado de Artículos por categoría dada");
            Console.WriteLine("3 - Alta de Artículo");
            Console.WriteLine("4 - Listado de Publicaciones entre fechas dadas");
            Console.WriteLine("5 - Listado de Publicaciones");
            Console.WriteLine("0 - Salir");
        }

        static void ListarClientes()
        {
            Console.Clear();
            CambioDeColor("Listado de Clientes", ConsoleColor.Yellow);
            Console.WriteLine();

            List<Usuario> todasLosClientes = miSistema.MostrarClientes();
            if (todasLosClientes.Count == 0)
            {
                MostrarError("No exiten Clientes en el sistema");
            }
            else
            {
                foreach (Usuario u in todasLosClientes)
                {
                    Console.WriteLine(u);
                }
            }

            PressToContinue();
        }

        static void ListarArticulosDadaCategoria()
        {
            Console.Clear();
            CambioDeColor("Listado de Artículos dada una Categoría", ConsoleColor.Yellow);
            Console.WriteLine();

            string categoria = PedirPalabras("Ingrese una categoría para buscar: ");

            List<Articulo> categoriaBuscada = miSistema.MostrarPorCategoria(categoria);
            if (categoriaBuscada.Count == 0)
            {
                MostrarError($"No exite la categoría: {categoria}");
            }
            else
            {
                foreach (Articulo a in categoriaBuscada)
                {
                    Console.WriteLine(a);
                }
            }

            PressToContinue();
        }

        static void AltaArticulo()
        {
            Console.Clear();
            CambioDeColor("Alta de Artículo", ConsoleColor.Yellow);
            Console.WriteLine();

            string nombre = PedirPalabras("Ingrese nombre del artículo: ");
            string categoria = PedirPalabras("Ingrese categoria del artículo: ");
            double precioVenta = PedirNumeros("Ingrese precio de venta del artículo: ");

            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("Ha ingresado un nombre vacio");
                if (string.IsNullOrEmpty(categoria)) throw new Exception("Ha ingresado una categoría vacia");
                if (precioVenta < 0) throw new Exception("El precio de venta no puede ser negativo");
                Articulo nuevoArticulo = new Articulo(nombre, categoria, precioVenta);
                miSistema.AltaArticulo(nuevoArticulo);
                MostrarExito("Artículo dado de alta correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }

            PressToContinue();
        }
        static void ListarPublicacionesEntreFechas()
        {
            Console.Clear();
            CambioDeColor("Listado de Publicaciones entre fechas dadas", ConsoleColor.Yellow);
            Console.WriteLine();

            DateTime fecha1 = PedirFecha("Ingrese la primer fecha: ");
            DateTime fecha2 = PedirFecha("Ingrese la segunda fecha: ");

            if (fecha1 > fecha2)
            {
                (fecha1, fecha2) = (fecha2, fecha1);
            }

            List<Publicacion> publicacionesEncontradas = miSistema.PublicacionesEntreFechas(fecha1, fecha2);
            if (publicacionesEncontradas.Count == 0)
            {
                MostrarError($"No existen publicaciones entre las fechas ingresadas");
            }
            else
            {
                foreach (Publicacion p in publicacionesEncontradas)
                {
                    Console.WriteLine(p);
                }
            }

            PressToContinue();
        }

        static void PressToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();
        }

        #endregion

        #region METODOS AUXILIARES

        static string PedirPalabras(string mensaje)
        {
            Console.Write(mensaje);
            string datosPedidos = Console.ReadLine();
            return datosPedidos;
        }

        static int PedirNumeros(string mensaje)
        {
            bool exito = false;
            int numero = 0;
            while (exito == false)
            {
                Console.Write(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);

                if (exito == false)
                {
                    MostrarError("ERROR: Debe ingresar solo numeros.");
                }
            }

            return numero;
        }

        static DateTime PedirFecha(string mensaje)
        {
            bool exito = false;
            DateTime fecha = new DateTime();

            while (!exito)
            {
                Console.Write($"{mensaje} [yyyy/MM/dd]:");
                exito = DateTime.TryParse(Console.ReadLine(), out fecha);

                if (!exito)
                {
                    MostrarError("ERROR: La fecha no respeta el formato yyyy/MM/dd");
                }
            }

            return fecha;
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void CambioDeColor(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion

        #region MÉTODOS EXTRAS DE PRUEBA
        static void ListarPublicaciones()
        {
            Console.Clear();
            CambioDeColor("Listado de Publicaciones", ConsoleColor.Yellow);
            Console.WriteLine();

            List<Publicacion> todasLasPublicaciones = miSistema.MostrarPublicaciones();
            if (todasLasPublicaciones.Count == 0)
            {
                MostrarError("No exiten Publicaciones en el sistema");
            }
            else
            {
                foreach (Publicacion u in todasLasPublicaciones)
                {
                    Console.WriteLine(u);
                }
            }

            PressToContinue();
        }

        #endregion
    }
}
