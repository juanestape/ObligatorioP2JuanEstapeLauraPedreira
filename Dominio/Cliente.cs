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

        public Cliente(string nombre, string apellido, string email, string contrasenia, double saldo) : base(nombre, apellido, email, contrasenia)
        {
            _saldo = saldo;
        }

        public override string ToString()
        {
            string retorno = $"Nombre: {_nombre} - Apellido: {_apellido} - Email: {_email} - Saldo: {_saldo}";

            return retorno;
        }

        public override bool Equals(object obj)
        {
            Cliente c = obj as Cliente;
            return c != null && this._id.Equals(c._id);
        }
    }
}
