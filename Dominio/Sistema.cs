using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        public List<Articulo> _articulos = new List<Articulo>();
        public List<Publicacion> _publicaciones = new List<Publicacion>();
        public List<Usuario> _usuarios = new List<Usuario>();

        public List<Usuario> MostrarClientes()
        {
            List<Usuario> listado = new List<Usuario>();
            foreach (Usuario c in _usuarios)
            {
                listado.Add(c);
            }
            return listado;
        }
        
        public List<Articulo> MostrarPorCategoria(string categoria)
        {
            List<Articulo> listado = new List<Articulo>();
            foreach (Articulo a in _articulos)
            {
                if(a.Categoria.ToUpper() == categoria.ToUpper()) listado.Add(a);
            }
            return listado;
        }


        public void AltaArticulo(Articulo articulo) 
        {
            {
                if (articulo == null) throw new Exception("El articulo no puede ser nulo");
                articulo.Validar();
                _articulos.Add(articulo);
            }
        }
       
        
        public List<Publicacion> PublicacionesEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            DateTime aux1 = fecha1;
            DateTime aux2 = fecha2;
            if (fecha1 > fecha2)
            {
                aux1 = fecha2;
                aux2 = fecha1;
            }
            foreach (Publicacion p in _publicaciones)
            {
                if (p.Fecha > aux1 && p.Fecha < aux2) publicaciones.Add(p);
            }
            return publicaciones;
        }
    }
}
