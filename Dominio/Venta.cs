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
            double descuento = 0;
            if (_ofertaR) descuento = 20;
            return descuento;
        }

        public override void Cerrar(Usuario usuarioFinaliza)
        {
            Cliente clienteFinaliza = usuarioFinaliza as Cliente;
            double precio = this.CalcularPrecio();

            if (clienteFinaliza.Saldo >= precio)
            {
                if (clienteFinaliza == null) throw new Exception("El Usuario no es válido");
                _estado = EstadoPublicacion.CERRADA;
                _clienteCompra = clienteFinaliza;
                _usuarioFinaliza = clienteFinaliza;
                _fechaFin = DateTime.Now;
                clienteFinaliza.Saldo -= precio;
            }
            throw new Exception("El Usuario no tiene saldo suficiente");
        }
    }
}


