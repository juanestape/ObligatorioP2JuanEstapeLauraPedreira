using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
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
    }
}
