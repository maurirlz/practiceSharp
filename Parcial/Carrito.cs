using System;
using System.Collections.Generic;

namespace Parcial
{
    public class Carrito
    {
        private List<Articulo> _listaDeArticulos;
        private Cliente _cliente;
        private decimal _precioTotal;

        public Carrito(Cliente cliente)
        {
            _cliente = cliente;
            _listaDeArticulos = new List<Articulo>();
        }

        public bool AgregarArticulo(Articulo a)
        {
            if (a != null)
            {
                _listaDeArticulos.Add(a);
                a.SetStock(a.GetStock() - 1);
                return true;
            }

            Console.WriteLine("No se pudo agregar el articulo deseado al carrito.");
            return false;
        }

        public bool QuitarArticulo(Articulo a)
        {
            if (EstaEnCarrito(a))
            {
                _listaDeArticulos.Remove(a);
                a.SetStock(a.GetStock() + 1);
                return true;
            }

            return false;
        }

        private bool EstaEnCarrito(Articulo a)
        {
            return _listaDeArticulos.Contains(a);
        }
        
        public List<Articulo> ListaDeArticulos => _listaDeArticulos;

        public Cliente Cliente => _cliente;

        public decimal PrecioTotal()
        {
            decimal acum = 0;
            
            foreach (Articulo articulo in _listaDeArticulos)
            {
                acum += articulo.GetPrecio;
            }
            
            _precioTotal = acum;
            return _precioTotal;
        }
    }
}