using System;
using System.Text;

namespace PrimerEjercicioOOP
{
    public class CuentaCorriente
    {
        /*
             Desarrolle una programa orientado a objetos en C#, para gestionar una clase cuenta corriente
             se caracteriza por tener asociado un numero de cuenta y un saldo disponible.
             Además, se puede:
             
             1. consultar el saldo disponible en cualquier momento,  x
             2. recibir depósitos x
             3. realizar extracciones y pagos. x
             
             Creara demás una clase Persona, que se caracteriza por:
              un DNI
              un array de cuentas bancarias. 
              
             La Persona puede tener asociada hasta 3 cuentas bancarias, y debe tener un
             método que permite añadir cuentas (hasta 3 que es el máximo). 
             También debe contener unmétodo que devuelva si la persona es morosa, ej., si tienen alguna cuenta con saldo negativo.
             
             Crear una clase Prueba Cuentas que instancie un objeto Persona con un dni cualquiera, así
             como dos objetos cuenta, una sin saldo inicial y otra con 700 euros. 
             
             La persona recibe la nomina mensual, por lo que ingresa 1100 euros en la primera cuenta, 
             pero tiene que pagar el alquiler de 750 euros con la segunda. 
            
             Imprimir por pantalla el si la persona es morosa.
             Posteriormente hacer una transferencia de una cuenta a otra y comprobar mostrándolo por
             pantalla que cambia el estado de la persona.
        */

        private readonly long _accountNumber;
        private decimal TotalBalance { get; set; }
        private decimal DebtStatus { get; set; }

        public CuentaCorriente(long accountNumber, decimal totalBalance)
        {
            _accountNumber = accountNumber;
             TotalBalance = totalBalance;
        }

        public CuentaCorriente(long accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public bool AddBalance(decimal amount)
        {

            if (amount > 0 && DebtStatus <= 0)
            {
                TotalBalance += amount;
                return true;
            }
            
            if (DebtStatus > 0)
            {
                decimal reminder = Math.Abs(DebtStatus - amount);
                DebtStatus = Math.Abs(DebtStatus - amount);
                
                if (reminder > 0)
                {
                    TotalBalance += reminder;
                    DebtStatus = 0;
                }

                return true;
            }

            return false;
        }

        public bool TransferBalanceToThisAccount(decimal amount, CuentaCorriente accountTransfering)
        {

            decimal firstAccountBalanceQuery = accountTransfering.BalanceQuery();

            if (amount <= firstAccountBalanceQuery)
            {
                accountTransfering.SubtractBalance(amount);
                AddBalance(amount);
                
                return true;
            }

            Console.WriteLine("Invalid amount of balance to transfer, account transfering doesn't meet the required balance for the transaction.");
            
            return false;
        }

        public bool SubtractBalance(decimal amount)
        {
            if (amount > TotalBalance)
            {
                TotalBalance = 0;
                DebtStatus += amount;

                return false;
            }

            TotalBalance -= amount;
            return true;
        }

        public long AccountNumber => _accountNumber;

        public decimal GetDebStatus => DebtStatus;

        public decimal BalanceQuery()
        {
            decimal totalBalance = TotalBalance;
            return totalBalance;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Account number: {_accountNumber}, status: ")
                .Append($"\n\t balance: {BalanceQuery()}")
                .Append($"\n\t debt status/amount: {DebtStatus}")
                .Append($"\n\t Has debt: {DebtStatus > 0}");

            return sb.ToString();
        }
    }
}