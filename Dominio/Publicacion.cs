using Dominio.Interfases;
using System.Linq;

namespace Dominio
{
    public abstract class Publicacion : IValidable
    {
        protected int _id;
        protected static int s_idUlt = 1;
        protected string _nombre;
        protected EstadoPublicacion _estado;
        protected DateTime _fechaPublicacion;
        protected List<Articulo> _articulos = new List<Articulo>();
        protected Usuario? _clienteCompra;
        protected Usuario? _usuarioFinaliza;
        protected DateTime? _fechaFin;

        public Publicacion(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _estado = estado;
            _fechaPublicacion = fechaPublicacion;
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
            set { _estado = value; }
        }

        public DateTime Fecha
        {
            get { return _fechaPublicacion; }
        }

        public List<Articulo> Articulo
        {
            get { return _articulos; }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio.");
        }

        public void AgregarArticulo(Articulo a) // Método que recibe un Artículo, lo valida y agrega a la lista de Artículos 
        {
            if (a == null) throw new Exception("El artículo no puede ser nulo");
            a.Validar();
            _articulos.Add(a);
        }
        public override string ToString()
        {
            string retorno = $"ID: {_id} - Nombre: {_nombre} - Estado {_estado} - Fecha de publicación: {_fechaPublicacion.ToShortDateString()}";

            return retorno;
        }

        public abstract string TipoPublicacion();

        public abstract double CalcularPrecio();

        public abstract void Cerrar(Usuario usuarioFinaliza);
    }
}
