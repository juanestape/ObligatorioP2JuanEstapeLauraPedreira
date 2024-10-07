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

        public void AltaOferta(Oferta o)
        {
            if (o == null) throw new Exception("La oferta no puede ser nulo");
            o.Validar();
            _ofertas.Add(o);
        }

        #region MÉTODOS EXTRAS DE PRUEBA
        //public override string ToString()
        //{

        //    string retorno = $"Nombre: {_nombre} - Estado Publicación: {_estado} - Fecha Publicación: {_fechaPublicacion.ToShortDateString()}";
        //    if (_ofertas.Count == 0)
        //    {
        //        retorno += $"\n --> SIN OFERTAS";
        //    }
        //    else
        //    {
        //        foreach (Oferta o in _ofertas)
        //        {
        //            retorno += $"\n --> {o.ToString()}";
        //        }
        //    }
        //    if (_articulos.Count == 0)
        //    {
        //        retorno += $"\n --> SIN ARTÍCULOS";
        //    }
        //    else
        //    {
        //        foreach (Articulo a in _articulos)
        //        {
        //            retorno += $"\n --> {a.ToString()}";
        //        }
        //    }
        //    return retorno;
        //}
        #endregion

    }
}
