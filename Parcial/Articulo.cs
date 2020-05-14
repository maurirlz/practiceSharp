using System;
using System.Text.RegularExpressions;

namespace Parcial
{
    public abstract class Articulo
    {
        private readonly string _nombre;
        private char _categoria;
        private decimal _precio;
        private long _stock;

        protected Articulo() : this(" ", ' ', 0, 0) {}

        // Constructor que no acepta una categoria y llama al constructor principal, puede ser un producto que no necesite o que se le dara despues 
        // dicha categoria.

        protected Articulo(string nombre, decimal precio, long stock)
            : this(nombre, ' ', precio, stock) {}

        // Constructor que acepta todos los parametros.

        protected Articulo(string nombre, char categoria, decimal precio, long stock)
        {
            if (Regex.IsMatch(nombre, "[a-zA-Z0-9]"))
            {
                _nombre = nombre;
            }
            else
            {
                throw new ArgumentException("Nombre a usar contiene caracteres invalidos.");
            }

            _categoria = categoria;

            if (precio > 0)
            {
                _precio = precio;
            }
            else
            {
                throw new ArgumentException("Precio a usar es negativo o 0.");
            }

            if (stock >= 0)
            {
                _stock = stock;
            }
            else
            {
                throw new ArgumentException("Stock a usar es negativo.");
            }
        }
        
        // Setteres y getters necesarios, solo setters en categoria (el articulo puede cambiar de categoria)
        // y stock (puede cambiar la cantidad de stock que tenemos de dicho articulo).
        // nombre, precio

        public string GetNombre => new string(_nombre);

        public decimal GetPrecio => _precio;

        public decimal SetPrecio(decimal nuevoPrecio) => nuevoPrecio > 0
            ? _precio = nuevoPrecio
            : throw new ArgumentException("Precio a modificar tiene un valor 0 o negativo.");
        
        public char GetCategoria => _categoria;
        
        public void SetCategoria(char nuevaCategoria) => _categoria = nuevaCategoria;

        public long GetStock() => _stock;

        public void SetStock(long nuevoStock) => _stock = nuevoStock;

        protected bool Equals(Articulo other)
        {
            return _nombre == other._nombre && _categoria == other._categoria && _precio == other._precio && _stock == other._stock;
        }
        
        // Sobreescribimos equals y hashcode() para poder comparar entre productos y ver si son iguales.
        // (equals por defecto solo compara la referencia de un objeto con la de otro, pero esto no significa que
        // sean iguales.

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Articulo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_nombre, _categoria, _precio, _stock);
        }
    }
}