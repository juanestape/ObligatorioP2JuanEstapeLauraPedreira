using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfases;

namespace Dominio
{
    public class Oferta : IValidable
    {
        private int _id;
        private static int s_idUlt = 1;
        private Cliente _cliente;
        private double _monto;
        private DateTime _fecha;

        public Oferta(Cliente cliente, double monto, DateTime fecha)
        {
            _id = s_idUlt;
            s_idUlt++;
            _cliente = cliente;
            _monto = monto;
            _fecha = fecha;
        }
        public int Id
        {
            get { return _id; }
        }

        public double Monto
        {
            get { return _monto; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
        }
        public void Validar()
        {
            if (_monto <= 0) throw new Exception("El monto de la oferta debe ser mayor a 0");
        }
    }
}
