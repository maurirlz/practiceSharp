using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PrimerEjercicioOOP
{
    public class Persona
    {
        /* Creara demás una clase Persona, que se caracteriza por:
              un DNI
              un array de cuentas bancarias. 
              
             La Persona puede tener asociada hasta 3 cuentas bancarias, y debe tener un
             método que permite añadir cuentas (hasta 3 que es el máximo). 
             
             También debe contener unmétodo que devuelva si la persona es morosa, ej., si tienen alguna cuenta con saldo negativo.
              */
        
        private string _dni;
        private List<CuentaCorriente> bankAccounts;
        
        private bool IsDebtor { get; set; }
        private bool HasAccountLimit { get; set; }
        
        public Persona(string dni, List<CuentaCorriente> bankAccounts)
        {
            if (Regex.IsMatch(dni, "[0-9]"))
            {

                _dni = dni;
            }
            else
            {
                Console.WriteLine("DNI couldn't be added since it doesn't correspond to the criteria for one.");
            }
            
            this.bankAccounts = new List<CuentaCorriente>();
        }

        public long AddBankAccount()
        {
            CheckForAccountLimit();
            
            if (!HasAccountLimit)
            {
                Random random = new Random();
                CuentaCorriente ncc = new CuentaCorriente(random.Next(1000000000), 0);
                
                bankAccounts.Add(ncc);
                return ncc.AccountNumber;
            }

            Console.WriteLine("Couldn't add a new bank account, bank account count > 3");

            return -1;
        }

        public long AddBankAccount(decimal amount)
        {
            
            CheckForAccountLimit();

            if (!HasAccountLimit)
            {

                Random random = new Random();
                CuentaCorriente ncc = new CuentaCorriente(random.Next(1000000000));
                
                bankAccounts.Add(ncc);
                return ncc.AccountNumber;
            }
            
            Console.WriteLine("Couldn't add a new bank account, bank account count > 3");

            return -1;
        }

        private void CheckForAccountLimit()
        {
            if (bankAccounts.Count >= 3)
            {
                HasAccountLimit = true;
            }
        }

        public bool CheckMorosityInBankAccounts()
        {
            
            bankAccounts.ForEach(bankAccount =>
            {
                if (bankAccount.GetDebStatus > 0)
                {
                    IsDebtor = true;
                } else if (bankAccount.GetDebStatus <= 0) 
                    IsDebtor = false;
            });

            return IsDebtor;
        }

        public CuentaCorriente GetCuentaCorriente(long id)
        {
            CuentaCorriente desiredBankAccount = bankAccounts.Find(bankAccount => bankAccount.AccountNumber == id);

            return desiredBankAccount;
        }
    }
}