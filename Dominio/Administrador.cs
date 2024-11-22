using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(string nombre, string apellido, string email, string contrasenia) : base(nombre, apellido, email, contrasenia)
        {
        }

        public override string Rol()
        {
            return "Administrador";
        }
    }
}
