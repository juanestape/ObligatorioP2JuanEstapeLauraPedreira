using System.Text.RegularExpressions;
using Dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Console.WriteLine("2 - Listado de Articulos por categoria dada");
            Console.WriteLine("3 - Alta de Articulo");
            Console.WriteLine("4 - Listado de Publicaciones entre fechas dadas");
            Console.WriteLine("0 - Salir");
        }

        static void ListarClientes()
        {
            Console.Clear();
            CambioDeColor("LISTADO DE CLIENTES", ConsoleColor.Yellow);
            Console.WriteLine();

            List<Usuario> todasLosClientes = miSistema.MostrarClientes();
            if (todasLosClientes.Count == 0)
            {
                MostrarError("No existen Clientes en el sistema");
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
            CambioDeColor("LISTADO DE ARTICULOS POR CATEGORIA DADA", ConsoleColor.Yellow);
            Console.WriteLine();

            string categoria = PedirPalabras("Ingrese una categoria para buscar: ");

            try
            {
                if (string.IsNullOrEmpty(categoria)) throw new Exception("Ha ingresado una categoria vacia");
                List<Articulo> articulosEncontrados = miSistema.ArticulosPorCategoria(categoria);
                if (articulosEncontrados.Count == 0)
                {
                    MostrarError($"No existe la categoria: {categoria}");
                }
                else
                {
                    foreach (Articulo a in articulosEncontrados)
                    {
                        Console.WriteLine(a);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }

            PressToContinue();
        }

        static void AltaArticulo()
        {
            Console.Clear();
            CambioDeColor("ALTA DE ARTICULO", ConsoleColor.Yellow);
            Console.WriteLine();

            string nombre = PedirPalabras("Ingrese nombre del articulo: ");
            string categoria = PedirPalabras("Ingrese categoria del articulo: ");
            double precioVenta = PedirNumeros("Ingrese precio de venta del articulo: ");

            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("Ha ingresado un nombre vacio");
                if (string.IsNullOrEmpty(categoria)) throw new Exception("Ha ingresado una categoria vacia");
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
            CambioDeColor("LISTADO DE PUBLICACIONES ENTRE FECHAS DADAS", ConsoleColor.Yellow);
            Console.WriteLine();

            DateTime fecha1 = PedirFecha("Ingrese la primer fecha: ");
            DateTime fecha2 = PedirFecha("Ingrese la segunda fecha: ");

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
            bool exito = false;
            string datosPedidos = string.Empty;
            while (exito == false)
            {
                Console.Write(mensaje);
                datosPedidos = Console.ReadLine();
                if (string.IsNullOrEmpty(datosPedidos))
                {
                    MostrarError("ERROR: Debe ingresar el dato solicitado.");
                }
                else
                {
                    exito = true;
                }
            }
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
    }
}
