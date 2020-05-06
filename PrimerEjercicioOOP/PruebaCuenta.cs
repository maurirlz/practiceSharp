using System;
using System.Collections.Generic;
using static System.Console;

namespace PrimerEjercicioOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Desarrolle una programa orientado a objetos en C#, para gestionar una clase cuenta corriente
             se caracteriza por tener asociado un numero de cuenta y un saldo disponible.
             Además, se puede consultar el saldo disponible en cualquier momento, recibir depósitos y realizar
             extracciones y pagos.
             Creara demás una clase Persona, que se caracteriza por un DNI y un array de cuentas
             bancarias. La Persona puede tener asociada hasta 3 cuentas bancarias, y debe tener un
             método que permite añadir cuentas (hasta 3 que es el máximo). También debe contener un
             método que devuelva si la persona es morosa, ej., si tienen alguna cuenta con saldo negativo.
             
             Crear una clase Prueba Cuentas que instancie un objeto Persona con un dni cualquiera, así
             como dos objetos cuenta, una sin saldo inicial y otra con 700 euros. La persona recibe la
             nomina mensual, por lo que ingresa 1100 euros en la primera cuenta, pero tiene que pagar el
             alquiler de 750 euros con la segunda. Imprimir por pantalla el si la persona es morosa.
             Posteriormente hacer una transferencia de una cuenta a otra y comprobar mostrándolo por
             pantalla que cambia el estado de la persona. 
             */
            
            Persona Mauricio = new Persona("32469622", new List<CuentaCorriente>());

            long idPrimeraCuentaMauricio = Mauricio.AddBankAccount(0);
            long idSegundaCuentaMauricio = Mauricio.AddBankAccount(700);

            CuentaCorriente primerCuenta = Mauricio.GetCuentaCorriente(idPrimeraCuentaMauricio);
            CuentaCorriente segundaCuenta = Mauricio.GetCuentaCorriente(idSegundaCuentaMauricio);

            primerCuenta.AddBalance(1100); // se ingresa 1100 en la primera cuenta.
            segundaCuenta.SubtractBalance(700);

            WriteLine($"Estado de morosidad del usuario: {Mauricio.CheckMorosityInBankAccounts()} "); // imprimo por pantalla si es morosa o no
            WriteLine(primerCuenta.ToString());
            WriteLine(segundaCuenta.ToString());
            
            WriteLine("------------------------------------------------------------------------------------");
            
            segundaCuenta.TransferBalanceToThisAccount(700, primerCuenta);
            WriteLine(primerCuenta.ToString());
            WriteLine(segundaCuenta.ToString());
            WriteLine($"Estado de morosidad del usuario: {Mauricio.CheckMorosityInBankAccounts()} ");
            
        }
    }
}