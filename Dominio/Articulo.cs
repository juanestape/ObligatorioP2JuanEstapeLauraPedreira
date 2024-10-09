using Dominio.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo : IValidable
    {
        private int _id;
        private static int s_idUlt = 1;
        private string _nombre;
        private string _categoria;
        private double _precioVenta;

        public Articulo(string nombre, string categoria, double precioVenta)
        {
            _id = s_idUlt;
            s_idUlt++;
            _nombre = nombre;
            _categoria = categoria;
            _precioVenta = precioVenta;
        }

        public string Categoria
        {
            get { return _categoria; }
        }

        public int Id
        {
            get { return _id; }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio.");
            if (string.IsNullOrEmpty(_categoria)) throw new Exception("La categoria no puede ser vacia.");
            if (_precioVenta <= 0) throw new Exception("El precio de venta debe ser mayor a 0");
        }

        public override string ToString()
        {
            string retorno = $"Nombre: {_nombre} - Categoría: {_categoria} - Precio de Venta: {_precioVenta}";

            return retorno;
        }

        public override bool Equals(object obj)
        {
            Articulo a = obj as Articulo;
            return a != null && this._id.Equals(a._id);
        }

    }
}
