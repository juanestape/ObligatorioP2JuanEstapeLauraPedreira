using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario // Asigna Cliente como hijo de la clase Usuario
    {
        private double _saldo;

        public Cliente(string nombre, string apellido, string email, string contrasenia, double saldo) : base(nombre, apellido, email, contrasenia) // Atribuye los valores de los atributos de la clase padre como base y le agrega el atributo propio de Cliente
        {
            _saldo = saldo;
        }

        public Cliente() : base() // Constructor sin parámetros para el model binding
        {
        }

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public override string ToString()
        {
            string retorno = $"Nombre: {_nombre} - Apellido: {_apellido} - Email: {_email} - Saldo: {_saldo}";

            return retorno;
        }
        public override bool Equals(object obj)
        {
            Cliente u = obj as Cliente;
            return u != null && this._email.Equals(u._email);
        }

        public override string Rol()
        {
            return "Cliente";
        }

        public void CargarSaldo(double cantidad)
        {
            if (cantidad <= 0) throw new Exception("El valor debe ser mayor a 0");
            _saldo += cantidad;
        }
    }
}
