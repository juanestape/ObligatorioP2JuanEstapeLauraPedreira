using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        private bool _ofertaR;

        public Venta(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion, bool ofertaR) : base(nombre, estado, fechaPublicacion)
        {
            _ofertaR = ofertaR;
        }
    }
}


