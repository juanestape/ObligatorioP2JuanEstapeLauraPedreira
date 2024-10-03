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
            _nombre = nombre;
            _categoria = categoria;
            _precioVenta = precioVenta;
        }

        public string Categoria
        {
            get { return _categoria; }
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(_nombre))throw new Exception("El nombre no puede ser vacio.");
            if(string.IsNullOrEmpty(_categoria)) throw new Exception("La categoria no puede ser vacia.");
            if (_precioVenta <= 0) throw new Exception("El precio de venta debe ser mayor a 0");
        }
    }
}
