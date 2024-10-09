﻿using System;
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
        private Usuario _cliente;
        private double _monto;
        private DateTime _fecha;

        public Oferta(Usuario cliente, double monto, DateTime fecha)
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

        public Usuario Cliente
        {
            get { return _cliente; }
        }
        public void Validar()
        {
            if (_monto <= 0) throw new Exception("El monto de la oferta debe ser mayor a 0");
        }

        #region MÉTODOS EXTRAS DE PRUEBA
        public override string ToString()
        {
            string retorno = $"ID: {_id} - Cliente: {_cliente} - Monto {_monto} - Fecha: {_fecha.ToShortDateString()}";

            return retorno;
        }
        #endregion
    }
}
