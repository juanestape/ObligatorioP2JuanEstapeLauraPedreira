using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(string nombre, string apellido, string email, string contraseña):base(nombre, apellido, email, contraseña)
        {

            // AGREGO COMENTARIO DOMINGO
            // 2
        }
    }
}
