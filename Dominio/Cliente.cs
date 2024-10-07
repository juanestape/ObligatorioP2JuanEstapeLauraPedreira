using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {
        private double _saldo;

        public Cliente(string nombre, string apellido, string email, string contraseña, double saldo) : base(nombre, apellido, email, contraseña)
        {
            _saldo = saldo;
        }

        public int Id
        {
            get { return _id; }
        }

        public override string ToString()
        {
            string retorno = $"Nombre: {_nombre} - Apellido: {_apellido} - Email: {_email} - Contraseña: {_contraseña} - Saldo: {_saldo}";

            return retorno;
        }
    }
}
