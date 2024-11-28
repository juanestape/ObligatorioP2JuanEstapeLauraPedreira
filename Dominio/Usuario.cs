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
        protected string _contrasenia;

        public Usuario(string nombre, string apellido, string email, string contrasenia)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _contrasenia = contrasenia;
        }

        public Usuario() // Constructor vacío de parámetro para el model binding
        {
            _id = s_idUlt;
            s_idUlt++;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        { 
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }


        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede ser vacio.");
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacio.");
            if (string.IsNullOrEmpty(_contrasenia) || _contrasenia.Length < 8) throw new Exception("La contraseña debe tener al menos 8 dígitos.");
        }

        public abstract string Rol();
    }
}
