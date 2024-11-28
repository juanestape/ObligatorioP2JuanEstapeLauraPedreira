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

        public override string TipoPublicacion()
        {
            return "Subasta";
        }

        public override double CalcularPrecio()
        {
            double precio = 0;
            if (_ofertas.Count > 0)
            {
                precio = this._ofertas[this._ofertas.Count - 1].Monto;
            }

            return precio;
        }

        public override void Cerrar(Usuario usuarioFinaliza)
        {
            Administrador administradorFinaliza = usuarioFinaliza as Administrador;
            if (administradorFinaliza == null) throw new Exception("El Usuario no es válido");

            bool clienteBuscado = false;

            for (int i = _ofertas.Count - 1; i >= 0; i--)
            {
                Oferta o = _ofertas[i];
                if (o.Cliente.Saldo >= o.Monto)
                {
                    _clienteCompra = o.Cliente;
                    o.Cliente.Saldo -= o.Monto;
                    _estado = EstadoPublicacion.CERRADA;
                    clienteBuscado = true;
                    break;
                }
            }

            if (clienteBuscado == false)
            {
                _estado = EstadoPublicacion.CANCELADA;
            }
            _usuarioFinaliza = administradorFinaliza;
            _fechaFin = DateTime.Now;
        }
    }
}
