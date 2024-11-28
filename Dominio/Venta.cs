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

        public override string TipoPublicacion()
        {
            return "Venta";
        }

        public override double CalcularPrecio()
        {
            double total = 0;
            foreach (Articulo a in _articulos)
            {
                total += a.PrecioVenta;
            }
            if (_ofertaR) total -= total * 0.20;

            return total;
        }

        public override void Cerrar(Usuario usuarioFinaliza)
        {
            Cliente clienteFinaliza = usuarioFinaliza as Cliente;
            if (clienteFinaliza == null) throw new Exception("El Usuario no es válido");

            double precio = this.CalcularPrecio();
            if (clienteFinaliza.Saldo < precio) throw new Exception($"No tienes saldo suficiente. Saldo actual: $ {clienteFinaliza.Saldo}.");

            _estado = EstadoPublicacion.CERRADA;
            _clienteCompra = clienteFinaliza;
            _usuarioFinaliza = clienteFinaliza;
            _fechaFin = DateTime.Now;
            clienteFinaliza.Saldo -= precio;

        }
    }
}


