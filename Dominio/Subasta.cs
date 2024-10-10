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

        public Subasta(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion) : base(nombre, estado, fechaPublicacion)
        {
        }

        public List<Oferta> Oferta
        {
            get { return _ofertas; }
        }

        public void AltaOferta(Oferta o) // Recibe una Oferta, la valida y la agrega al listado de Ofertas
        {
            if (o == null) throw new Exception("La oferta no puede ser nulo");
            o.Validar();
            if (_ofertas.Count > 0 && o.Monto <= this._ofertas[this._ofertas.Count - 1].Monto) throw new Exception("La oferta debe ser mayor a la oferta mas alta");
            _ofertas.Add(o);
        }
    }
}
