using System;

namespace Parcial
{
    public class Test
    {
        static void Main()
        {
            ArticuloPerecedero salsa = new ArticuloPerecedero("Salsa Marolio", 'p', 50, 100, 
                new DateTime(2020, 05, 28));
            
            ArticuloNoPerecedero arroz = new ArticuloNoPerecedero("Arroz Marolio", 'n', 30, 100);
            
            Cliente test = new Cliente("Mauricio", "Benitez", "54936245555", "test@gmail.com", 500);
            
            Carrito carritoComida = new Carrito(test);

            Console.WriteLine($"Stock de salsa: {salsa.GetStock()}");
            carritoComida.AgregarArticulo(salsa);
            carritoComida.AgregarArticulo(arroz);

            Console.WriteLine($"Stock de salsa despues de agregar: {salsa.GetStock()}");
            
            test.AgregarCarrito(carritoComida);
            test.ListaDeCarritos();
            Console.WriteLine("Total a pagar: " + test.PreguntarTotalAPagar());
        }
    }
}