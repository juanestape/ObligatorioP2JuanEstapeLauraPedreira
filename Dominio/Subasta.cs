using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();

        public Subasta(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulos, List<Oferta> ofertas):base(nombre, estado, fechaPublicacion, articulos) 
        {
         _ofertas = ofertas;
        }

        public void AltaOferta() { }

    }
}
