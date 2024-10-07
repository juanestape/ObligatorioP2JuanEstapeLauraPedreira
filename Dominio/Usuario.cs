using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfases;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        protected int _id;
        protected static int s_idUlt = 1;
        protected string _nombre;
        protected string _apellido;
        protected string _email;
        protected string _contraseña;

        public Usuario(string nombre, string apellido, string email, string contraseña)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _contraseña = contraseña;
        }

        public int Id
        {
            get { return _id; }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede ser vacio.");
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacio.");
            if (string.IsNullOrEmpty(_contraseña)) throw new Exception("La contraseña no puede ser vacia.");
        }
    }
}
