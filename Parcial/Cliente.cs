using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Parcial
{
    public class Cliente : Persona
    {
        private List<Carrito> _listaDeCarritos;
        private decimal _dineroAEntregar;
        private bool puedePagar;

        public Cliente(string nombre, string apellido, decimal cantidadDeDineroAPagar) : this(nombre, apellido, "0000000", "testemail@test.com", 
            cantidadDeDineroAPagar) {}
        
        public Cliente(string nombre, string apellido, string email, decimal cantidadDeDineroAPagar) : this(nombre, apellido, "0000000", 
            email, cantidadDeDineroAPagar) {}

        public Cliente(string nombre, string apellido, string telefono, string email, decimal cantidadDeDineroAPagar) : base(nombre, apellido, telefono,
            email)
        {
            _dineroAEntregar = cantidadDeDineroAPagar;
                
            _listaDeCarritos = new List<Carrito>();
        }

        public void AgregarCarrito(Carrito c)
        {
            _listaDeCarritos.Add(c);
        }

        public void QuitarCarrito(Carrito c)
        {
            _listaDeCarritos.Remove(c);
        }

        public decimal PreguntarTotalAPagar()
        {
            decimal acum = 0;
            
            foreach (Carrito carrito in _listaDeCarritos)
            {
                foreach (Articulo articulo in carrito.ListaDeArticulos)
                {
                    acum += articulo.GetPrecio;
                }
            }

            return acum;
        }

        public void ListaDeCarritos()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;

            foreach (Carrito carrito in _listaDeCarritos)
            {
                sb.Append($"\tCarrito {i}: ");
                foreach (Articulo articulo in carrito.ListaDeArticulos)
                {
                    sb.Append($"\n\tProducto: {articulo.GetNombre}");
                    sb.Append($"\t\tPrecio: {articulo.GetPrecio}");
                    sb.Append($"\t\tCategoria: {articulo.GetCategoria}");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}