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
            double descuento = 0;
            if (_ofertaR) descuento = 20;
            return descuento;
        }
        public override void Cerrar(Usuario usuarioFinaliza)
        {
            Cliente clienteFinaliza = usuarioFinaliza as Cliente;

            _estado = EstadoPublicacion.CERRADA;
            _clienteCompra = clienteFinaliza;
            _usuarioFinaliza = clienteFinaliza;
            _fechaFin = DateTime.Now;
            //clienteFinaliza.Saldo -= this.CalcularPrecio();
        }
    }
}


