using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfases;

namespace Dominio
{
    internal class Oferta : IValidable
    {
        private int _id;
        private static int s_idUlt = 1;
        private Usuario _cliente;
        private double _monto;
        private DateTime _fecha;

        public Oferta(Usuario cliente, double monto, DateTime fecha)
        {
            _cliente = cliente;
            _monto = monto;
            _fecha = fecha;
        }

        public void Validar()
        {
            if(_monto <= 0)throw new Exception("El monto de la oferta debe ser mayor a 0"); 
        }
    }
}
