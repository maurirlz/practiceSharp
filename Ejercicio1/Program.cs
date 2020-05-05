using System;

namespace practiceSharp
{
    class Program
    {
        static void Main(string[] args)
        { 
            /*
        * 2.  Mostrar “Introduzca un número” : Pedir Num
        * 3.  Res = Num mod 2
        * 4.  Si Res = 0 Entonces
            * Mostrar “El número es par”
        SiNo
            Mostrar “El número es impar”
        FinSi
        * Fin
           */ 
            
            Console.WriteLine("Introduzca un numero: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = number % 2;

            if (result == 0)
            {
                
                Console.WriteLine("Number inputted is even.");
            }
            else
            {
                Console.WriteLine("Number is odd");
            }
        }
    }
}