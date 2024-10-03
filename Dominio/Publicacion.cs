using Dominio.Interfases;
using System.Linq;

namespace Dominio
{
    public class Publicacion : IValidable
    {

        protected int _id;
        protected static int s_idUlt = 1;
        protected string _nombre;
        protected EstadoPublicacion _estado;
        protected DateTime _fechaPublicacion;
        protected List<Articulo> _articulos = new List<Articulo>;
        protected Usuario? _clienteCompra;
        protected Usuario? _usuarioFinaliza;
        protected DateTime? _fechaFin;


        public Publicacion(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulos)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _estado = estado;
            _fechaPublicacion = fechaPublicacion;
            _articulos = articulos;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public EstadoPublicacion Estado
        {
            get { return _estado; }
        }

        public DateTime Fecha
        {
            get { return _fechaPublicacion; }
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(_nombre))throw new Exception("El nombre no puede ser vacio.");
        }   
    }
}
