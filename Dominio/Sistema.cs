﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema s_instancia; // Primer paso Singleton para no permitir crear más de una instancia de sistema

        public List<Articulo> _articulos = new List<Articulo>();
        public List<Publicacion> _publicaciones = new List<Publicacion>();
        public List<Usuario> _usuarios = new List<Usuario>();
        private Sistema() // Se invocan los métodos de precarga para que el Sistema inicie con datos // Segundo paso Singleton: hacer privado el contructor de sistema
        {
            PrecargarArticulos();
            PrecargarUsuarios();
            PrecargarPublicaciones();
            PrecargarArticuloAPublicacion();
            PrecargarOfertasASubastas();
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }

        public void AltaUsuarios(Usuario usuario)
        {
            {
                if (usuario == null) throw new Exception("El usuario no puede ser nulo");

                bool tieneRegistro = false;
                if (_usuarios.Contains(usuario)) tieneRegistro = true;

                if (tieneRegistro) throw new Exception("Ya existe un usuario con ese email");
                usuario.Validar();

                if (!tieneRegistro)
                {
                    _usuarios.Add(usuario);
                }
            }
        }

        public static Sistema Instancia // Tercer paso Singleton: hacer la property estática del atributo. Entonces si el atributo es nulo, genero un nuevo objeto de tipo Sistema, y siempre retorno ese objeto guardado en el atributo
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }


        private void PrecargarUsuarios() // Utiliza el métdo AltaUsuarios para crear un nuevo Usuario tipo Administrador o Cliente
        {
            AltaUsuarios(new Administrador("Alejandro", "García", "alejandro.garcia@admin.com", "AdminAle1234"));
            AltaUsuarios(new Administrador("Camila", "Díaz", "camila.diaz@admin.com", "AdminCamila1234"));
            AltaUsuarios(new Cliente("Juan", "Pérez", "juan.perez@mail.com", "Juan1234", 1200));
            AltaUsuarios(new Cliente("María", "López", "maria.lopez@mail.com", "Maria5678", 2500));
            AltaUsuarios(new Cliente("Carlos", "Gómez", "carlos.gomez@mail.com", "CarGo123", 4500));
            AltaUsuarios(new Cliente("Laura", "Fernández", "laura.fernandez@mail.com", "LauFer789", 1800));
            AltaUsuarios(new Cliente("Pedro", "Rodríguez", "pedro.rodriguez@mail.com", "PedroRz987", 3200));
            AltaUsuarios(new Cliente("Ana", "Sánchez", "ana.sanchez@mail.com", "AnaSnchz456", 1000));
            AltaUsuarios(new Cliente("Luis", "Martínez", "luis.martinez@mail.com", "LuisMtz234", 100));
            AltaUsuarios(new Cliente("Sofía", "Ramírez", "sofia.ramirez@mail.com", "SofRam123", 30));
            AltaUsuarios(new Cliente("Diego", "Torres", "diego.torres@mail.com", "DiegoTor789", 20));
            AltaUsuarios(new Cliente("Valentina", "Morales", "valentina.morales@mail.com", "ValeMor456", 5000));
        }

        public void AltaArticulo(Articulo articulo)
        {
            {
                if (articulo == null) throw new Exception("El articulo no puede ser nulo");
                if (_articulos.Contains(articulo)) throw new Exception("Este articulo ya existe");
                articulo.Validar();
                _articulos.Add(articulo);
            }
        }

        private void PrecargarArticulos()
        {
            AltaArticulo(new Articulo("Balde de Playa", "Juguetes", 250));
            AltaArticulo(new Articulo("Sombrilla de Playa", "Accesorios", 500));
            AltaArticulo(new Articulo("Protector Solar SPF 50", "Cuidado Personal", 300));
            AltaArticulo(new Articulo("Salvavidas Inflable", "Deportes Acuáticos", 400));
            AltaArticulo(new Articulo("Bicicleta de Carrera", "Deportes", 950));
            AltaArticulo(new Articulo("Malla para Natación", "Deportes", 450));
            AltaArticulo(new Articulo("Zapatillas de Ciclismo", "Deportes", 850));
            AltaArticulo(new Articulo("Gorra de Verano", "Ropa", 200));
            AltaArticulo(new Articulo("Toalla de Playa", "Accesorios", 350));
            AltaArticulo(new Articulo("Silla Plegable", "Mobiliario", 700));
            AltaArticulo(new Articulo("Cámara Acuática", "Electrónica", 850));
            AltaArticulo(new Articulo("Gafas de Sol Polarizadas", "Accesorios", 450));
            AltaArticulo(new Articulo("Bolso de Playa Impermeable", "Accesorios", 550));
            AltaArticulo(new Articulo("Parasol para Auto", "Automotriz", 300));
            AltaArticulo(new Articulo("Carpa de Playa", "Camping", 800));
            AltaArticulo(new Articulo("Cerveza Artesanal Pack 6", "Alimentos y Bebidas", 600));
            AltaArticulo(new Articulo("Helado de Frutas", "Alimentos y Bebidas", 250));
            AltaArticulo(new Articulo("Parrilla Portátil", "Accesorios de Cocina", 700));
            AltaArticulo(new Articulo("Guantes de Ciclismo", "Deportes", 300));
            AltaArticulo(new Articulo("Linterna para Camping", "Camping", 400));
            AltaArticulo(new Articulo("Cantimplora de Acero", "Camping", 350));
            AltaArticulo(new Articulo("Raqueta de Tenis", "Deportes", 750));
            AltaArticulo(new Articulo("Paleta de Pádel", "Deportes", 650));
            AltaArticulo(new Articulo("Aletas para Buceo", "Deportes Acuáticos", 500));
            AltaArticulo(new Articulo("Tubo de Snorkel", "Deportes Acuáticos", 300));
            AltaArticulo(new Articulo("Colchón Inflable", "Camping", 600));
            AltaArticulo(new Articulo("Remera de Ciclismo", "Ropa Deportiva", 400));
            AltaArticulo(new Articulo("Bañador para Hombre", "Ropa", 350));
            AltaArticulo(new Articulo("Bañador para Mujer", "Ropa", 400));
            AltaArticulo(new Articulo("Sombrero de Paja", "Accesorios", 200));
            AltaArticulo(new Articulo("Lentes de Natación", "Deportes", 350));
            AltaArticulo(new Articulo("Pelota de Vóley", "Deportes", 400));
            AltaArticulo(new Articulo("Juego de Raquetas de Playa", "Juguetes", 300));
            AltaArticulo(new Articulo("Sandalias de Playa", "Ropa", 250));
            AltaArticulo(new Articulo("Cargador Solar Portátil", "Electrónica", 800));
            AltaArticulo(new Articulo("Gorro de Natación", "Deportes", 250));
            AltaArticulo(new Articulo("Termo de Acero Inoxidable", "Accesorios", 450));
            AltaArticulo(new Articulo("Mochila de Hidratación", "Deportes", 700));
            AltaArticulo(new Articulo("Kit de Pesca Básico", "Deportes", 650));
            AltaArticulo(new Articulo("Baraja de Cartas Impermeable", "Juguetes", 200));
            AltaArticulo(new Articulo("Colchoneta de Yoga", "Deportes", 350));
            AltaArticulo(new Articulo("Bebida Energética Pack 12", "Alimentos y Bebidas", 500));
            AltaArticulo(new Articulo("Bolso de Deporte", "Accesorios", 450));
            AltaArticulo(new Articulo("Cuchillo de Supervivencia", "Camping", 400));
            AltaArticulo(new Articulo("Cinturón de Pesas", "Deportes", 600));
            AltaArticulo(new Articulo("Botella de Agua Reutilizable", "Accesorios", 300));
            AltaArticulo(new Articulo("Vincha Deportiva", "Accesorios", 200));
            AltaArticulo(new Articulo("Juego de Pesas", "Deportes", 900));
            AltaArticulo(new Articulo("Cargador de Bicicleta Eléctrica", "Electrónica", 750));
            AltaArticulo(new Articulo("Bate de Béisbol", "Deportes", 500));
        }
        public void AltaPublicacion(Publicacion publicacion)
        {
            {
                if (publicacion == null) throw new Exception("La publicación no puede ser nula");
                publicacion.Validar();
                _publicaciones.Add(publicacion);
            }
        }
        private void PrecargarPublicaciones()
        {
            AltaPublicacion(new Venta("Verano en la Playa", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 15), true));
            AltaPublicacion(new Venta("Aventura en el Camping", EstadoPublicacion.CERRADA, new DateTime(2024, 08, 12), false));
            AltaPublicacion(new Venta("Pack de Ciclismo", EstadoPublicacion.ABIERTA, new DateTime(2024, 10, 02), false));
            AltaPublicacion(new Venta("Picnic en el Parque", EstadoPublicacion.ABIERTA, new DateTime(2024, 07, 20), false));
            AltaPublicacion(new Venta("Equipamiento para Tenis", EstadoPublicacion.ABIERTA, new DateTime(2024, 08, 05), false));
            AltaPublicacion(new Venta("Jornada de Pesca", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 29), true));
            AltaPublicacion(new Venta("Energía en el Deporte", EstadoPublicacion.ABIERTA, new DateTime(2024, 08, 30), false));
            AltaPublicacion(new Venta("Día de Playa", EstadoPublicacion.ABIERTA, new DateTime(2024, 07, 10), false));
            AltaPublicacion(new Venta("Fitness en Casa", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 25), true));
            AltaPublicacion(new Venta("Equipamiento para Pádel", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 12), false));
            AltaPublicacion(new Subasta("Ciclismo Profesional", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 20)));
            AltaPublicacion(new Subasta("Camping Completo", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 18)));
            AltaPublicacion(new Subasta("Equipamiento de Pesca", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 25)));
            AltaPublicacion(new Subasta("Playa", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 29)));
            AltaPublicacion(new Subasta("Tenis Avanzado", EstadoPublicacion.ABIERTA, new DateTime(2024, 09, 26)));
            AltaPublicacion(new Subasta("Ciclista", EstadoPublicacion.ABIERTA, new DateTime(2024, 08, 15)));
            AltaPublicacion(new Subasta("Día de Playa Completo", EstadoPublicacion.ABIERTA, new DateTime(2024, 07, 05)));
            AltaPublicacion(new Subasta("Kit de Supervivencia", EstadoPublicacion.CERRADA, new DateTime(2024, 08, 01)));
            AltaPublicacion(new Subasta("Deportes Acuáticos", EstadoPublicacion.ABIERTA, new DateTime(2024, 07, 20)));
            AltaPublicacion(new Subasta("Fitness Completo", EstadoPublicacion.ABIERTA, new DateTime(2024, 06, 28)));
        }

        // MÉTODOS PARA PRECARGAR ARTICULOS A PUBLICACIONES
        public Publicacion ObtenerPublicacionPorId(int id) // Método para conseguir objeto a través del Id
        {
            Publicacion buscada = null;
            int i = 0;
            while (i < _publicaciones.Count && buscada == null)
            {
                if (_publicaciones[i].Id == id) buscada = _publicaciones[i];
                i++;
            }
            return buscada;
        }

        public Articulo ObtenerArticuloPorId(int id)
        {
            Articulo buscado = null;
            int i = 0;
            while (i < _articulos.Count && buscado == null)
            {
                if (_articulos[i].Id == id) buscado = _articulos[i];
                i++;
            }
            return buscado;
        }
        public void AgregarArticuloAPublicacion(int idPublicacion, int idArticulo) // Recibe un Id de Publicación y un Id de Artículos, los busca con los métodos anteriores y agrega el artículo a la publicación
        {
            Publicacion publicacionBuscada = ObtenerPublicacionPorId(idPublicacion);
            if (publicacionBuscada == null) throw new Exception("No se encontro publicacion con ese Id");
            Articulo articuloBuscado = ObtenerArticuloPorId(idArticulo);
            if (articuloBuscado == null) throw new Exception("No se encontro articulo con ese Id");
            if (publicacionBuscada.Articulo.Contains(articuloBuscado)) throw new Exception("Este articulo ya existe en la publicacion");
            publicacionBuscada.AgregarArticulo(articuloBuscado);
        }

        private void PrecargarArticuloAPublicacion()
        {
            AgregarArticuloAPublicacion(1, 1);
            AgregarArticuloAPublicacion(1, 2);
            AgregarArticuloAPublicacion(1, 3);
            AgregarArticuloAPublicacion(1, 4);

            AgregarArticuloAPublicacion(2, 21);
            AgregarArticuloAPublicacion(2, 20);
            AgregarArticuloAPublicacion(2, 15);
            AgregarArticuloAPublicacion(2, 26);
            AgregarArticuloAPublicacion(2, 44);

            AgregarArticuloAPublicacion(3, 1);
            AgregarArticuloAPublicacion(3, 2);
            AgregarArticuloAPublicacion(3, 3);
            AgregarArticuloAPublicacion(3, 4);

            AgregarArticuloAPublicacion(4, 18);
            AgregarArticuloAPublicacion(4, 37);
            AgregarArticuloAPublicacion(4, 16);
            AgregarArticuloAPublicacion(4, 17);

            AgregarArticuloAPublicacion(5, 22);
            AgregarArticuloAPublicacion(5, 36);
            AgregarArticuloAPublicacion(5, 31);

            AgregarArticuloAPublicacion(6, 39);
            AgregarArticuloAPublicacion(6, 21);
            AgregarArticuloAPublicacion(6, 30);

            AgregarArticuloAPublicacion(7, 42);
            AgregarArticuloAPublicacion(7, 38);
            AgregarArticuloAPublicacion(7, 47);
            AgregarArticuloAPublicacion(7, 46);

            AgregarArticuloAPublicacion(8, 4);
            AgregarArticuloAPublicacion(8, 33);
            AgregarArticuloAPublicacion(8, 1);
            AgregarArticuloAPublicacion(8, 3);

            AgregarArticuloAPublicacion(9, 48);
            AgregarArticuloAPublicacion(9, 41);
            AgregarArticuloAPublicacion(9, 45);

            AgregarArticuloAPublicacion(10, 23);
            AgregarArticuloAPublicacion(10, 7);
            AgregarArticuloAPublicacion(10, 12);

            AgregarArticuloAPublicacion(11, 5);
            AgregarArticuloAPublicacion(11, 7);
            AgregarArticuloAPublicacion(11, 27);
            AgregarArticuloAPublicacion(11, 19);

            AgregarArticuloAPublicacion(12, 15);
            AgregarArticuloAPublicacion(12, 21);
            AgregarArticuloAPublicacion(12, 20);
            AgregarArticuloAPublicacion(12, 26);

            AgregarArticuloAPublicacion(13, 39);
            AgregarArticuloAPublicacion(13, 30);
            AgregarArticuloAPublicacion(13, 44);

            AgregarArticuloAPublicacion(14, 2);
            AgregarArticuloAPublicacion(14, 3);
            AgregarArticuloAPublicacion(14, 9);
            AgregarArticuloAPublicacion(14, 4);

            AgregarArticuloAPublicacion(15, 22);
            AgregarArticuloAPublicacion(15, 36);
            AgregarArticuloAPublicacion(15, 31);

            AgregarArticuloAPublicacion(16, 5);
            AgregarArticuloAPublicacion(16, 7);
            AgregarArticuloAPublicacion(16, 8);

            AgregarArticuloAPublicacion(17, 2);
            AgregarArticuloAPublicacion(17, 9);
            AgregarArticuloAPublicacion(17, 3);

            AgregarArticuloAPublicacion(18, 44);
            AgregarArticuloAPublicacion(18, 21);
            AgregarArticuloAPublicacion(18, 20);

            AgregarArticuloAPublicacion(19, 24);
            AgregarArticuloAPublicacion(19, 25);
            AgregarArticuloAPublicacion(19, 12);

            AgregarArticuloAPublicacion(20, 48);
            AgregarArticuloAPublicacion(20, 41);
            AgregarArticuloAPublicacion(20, 45);
        }

        // MÉTODOS PARA PRECARGAR OFERTAS A SUBASTAS
        public Subasta ObtenerSubastaPorId(int id)
        {
            Subasta buscada = null;
            int i = 0;
            while (i < _publicaciones.Count && buscada == null)
            {
                if (_publicaciones[i].Id == id && _publicaciones[i] is Subasta) buscada = _publicaciones[i] as Subasta;
                i++;
            }
            return buscada;
        }
        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario buscado = null;
            int i = 0;
            while (i < _usuarios.Count && buscado == null)
            {
                if (_usuarios[i].Id == id) buscado = _usuarios[i];
                i++;
            }
            return buscado;
        }

        public void AgregaroOfertaASubasta(int idSubasta, int idCliente, double monto, DateTime fecha) // Método para agregar una oferta a una subasta
        {
            Subasta subastaBuscada = ObtenerSubastaPorId(idSubasta);
            if (subastaBuscada == null) throw new Exception($"No se encontro subasta con ese Id: {idSubasta}");
            Cliente clienteBuscado = ObtenerClientePorId(idCliente);
            if (clienteBuscado == null) throw new Exception($"No se encontro cliente con ese Id: {idCliente}");
            bool tieneOferta = false;
            foreach (Oferta a in subastaBuscada.Oferta)
            {
                if (a.Cliente.Equals(clienteBuscado)) tieneOferta = true;
            }
            if (tieneOferta) throw new Exception($"El cliente {clienteBuscado.Email} ya realizo una oferta");
            Oferta o = new Oferta(clienteBuscado, monto, fecha);
            subastaBuscada.AltaOferta(o);
        }
        private void PrecargarOfertasASubastas()
        {
            AgregaroOfertaASubasta(11, 5, 800, new DateTime(2024, 09, 22));
            AgregaroOfertaASubasta(11, 9, 950, new DateTime(2024, 09, 24));
            AgregaroOfertaASubasta(12, 3, 600, new DateTime(2024, 09, 20));
            AgregaroOfertaASubasta(12, 7, 850, new DateTime(2024, 09, 23));
            AgregaroOfertaASubasta(13, 10, 1200, new DateTime(2024, 09, 20));
            AgregaroOfertaASubasta(13, 11, 1350, new DateTime(2024, 09, 23));
        }

        public List<Usuario> MostrarClientes()
        {
            List<Usuario> clientesBuscados = new List<Usuario>();
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente) clientesBuscados.Add(u);
            }
            return clientesBuscados;
        }

        public List<Articulo> ArticulosPorCategoria(string categoria)
        {
            List<Articulo> listado = new List<Articulo>();
            foreach (Articulo a in _articulos)
            {
                if (a.Categoria.ToUpper() == categoria.ToUpper()) listado.Add(a);
            }
            return listado;
        }

        public List<Publicacion> PublicacionesEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            if (fecha1 > fecha2)
            {
                (fecha1, fecha2) = (fecha2, fecha1);
            }

            foreach (Publicacion p in _publicaciones)
            {
                if (p.Fecha.Date >= fecha1 && p.Fecha.Date <= fecha2) publicaciones.Add(p);
            }
            return publicaciones;
        }

        public Usuario Login(string email, string contrasena) // Método Login para los dos tipos de Usuarios
        {
            Usuario usuarioBuscado = null;
            int i = 0;
            while (usuarioBuscado == null && i < _usuarios.Count)
            {
                if (_usuarios[i].Email == email && _usuarios[i].Contrasenia == contrasena) usuarioBuscado = _usuarios[i]; // Busco en la lista de Usuarios el que coincida con el email y contraseña que viene por parametro
                i++;
            }
            return usuarioBuscado;
        }

        public int ObtenerIdUsuarioPorEmail(string email) // Método para obtener el id del usuario logueado usando el email que guardamos en la session
        {
            int idBuscado = 0;
            int i = 0;
            while (idBuscado <= 0 && i < _usuarios.Count)
            {
                if (_usuarios[i].Email == email) idBuscado = _usuarios[i].Id;
                i++;
            }
            return idBuscado;
        }

        public Cliente ObtenerClientePorId(int id)
        {
            Cliente buscado = null;
            int i = 0;
            while (i < _usuarios.Count && buscado == null)
            {
                if (_usuarios[i].Id == id && _usuarios[i] is Cliente) buscado = _usuarios[i] as Cliente;
                i++;
            }
            return buscado;
        }

        public Venta ObtenerVentaPorId(int id)
        {
            Venta buscada = null;
            int i = 0;
            while (i < _publicaciones.Count && buscada == null)
            {
                if (_publicaciones[i].Id == id && _publicaciones[i] is Venta) buscada = _publicaciones[i] as Venta;
                i++;
            }
            return buscada;
        }

        public void CambiarSaldoDeCliente(int idCliente, double cantidad)
        {
            Cliente c = ObtenerClientePorId(idCliente);
            if (c == null) throw new Exception($"El Cliente {idCliente} no se encontró");
            c.CargarSaldo(cantidad);
        }

        public void CerrarPublicacion(int idUsuario, int idPublicacion)
        {
            Usuario u = ObtenerUsuarioPorId(idUsuario);
            Publicacion p = ObtenerPublicacionPorId(idPublicacion);
            p.Cerrar(u);
        }

        public List<Publicacion> PublicacionesOrdenadasPorFecha()
        {
            _publicaciones.Sort(); // Invocamos el método sort para ordenar. En este caso al ser un objeto tengo que decirle a través del método ComparteTo que usa por detrás, cual es la forma que quiero usar para ordenar
            return _publicaciones;
        }

        public double SaldoActual(int idUsuario)
        {
            Cliente c = ObtenerClientePorId(idUsuario);
            return c.Saldo;
        }
    }
}
