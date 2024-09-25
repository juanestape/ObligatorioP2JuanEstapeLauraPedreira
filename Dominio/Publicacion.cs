namespace Dominio
{
    public class Publicacion
    {

        protected int _id;
        protected static int s_idUlt = 1;
        protected string _nombre;
        protected EstadoPublicacion _estado;
        protected DateTime _fechaPublicacion;
        protected List<Articulo> _articulos = new List<Articulo>;
        protected Usuario _clienteCompra;
        protected Usuario _usuarioFinaliza;
        protected DateTime _fechaFin;

        public Publicacion(string nombre, EstadoPublicacion estado, DateTime fechaPublicacion, List<Articulo> articulos)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _estado = estado;
            _fechaPublicacion = fechaPublicacion;
            _articulos = articulos;
        }
    }
}
