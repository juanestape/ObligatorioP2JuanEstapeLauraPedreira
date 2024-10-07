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

        #region MÉTODOS EXTRAS DE PRUEBA
        public override string ToString()
        {
            string oferta = string.Empty;
            if (_ofertaR) oferta = "Sí";
            else oferta = "No";

            string retorno = $"Nombre: {_nombre} - Estado Publicación: {_estado} - Fecha Publicación: {_fechaPublicacion.ToShortDateString()} - Oferta: {oferta}";
            if (_articulos.Count == 0)
            {
                retorno += $"\n --> SIN ARTÍCULOS";
            }
            else
            {
                foreach (Articulo a in _articulos)
                {
                    retorno += $"\n --> {a.ToString()}";
                }
            }
            return retorno;
        }
        #endregion
    }
}


