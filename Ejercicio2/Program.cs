using System;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Desarrollar una aplicacion en c# para que dado un número de entrada calcule su
             * correspondiente tabla de multiplicar
             */ 
            
            Console.WriteLine("Input an Integer: ");
            int number = Convert.ToInt32(Console.Read());

            Console.WriteLine("Tabla de multiplicar: ");
            for (int j = 0; j < number; j++)
            {
                Console.WriteLine(j * number);
            }
        }
    }
}