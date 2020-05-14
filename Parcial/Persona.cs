using System;
using System.Text.RegularExpressions;

namespace Parcial
{
    public abstract class Persona
    {
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _email;
        
        // Una persona puede no tener ni email ni telefono.

        protected Persona(string nombre, string apellido) : this(nombre, apellido, "testemail@test.com"){}

        // una persona puede no tener telefono.
        
        protected Persona(string nombre, string apellido, string email) : this(nombre, apellido, "0000000", email) { }

        // Constructor que acepta todos los parametros.
        
        protected Persona(string nombre, string apellido, string telefono, string email)
        {
            if (Regex.IsMatch(nombre, "[a-zA-Z]"))
            {
                _nombre = nombre;
            } else {
                throw new ArgumentException("Nombre a usar contiene caracteres invalidos.");
            }
            
            if (Regex.IsMatch(apellido, "[a-zA-Z]"))
            {
                _apellido = apellido;
            } else {
                throw new ArgumentException("Apellido a usar contiene caracteres invalidos.");
            }
            
            if (Regex.IsMatch(telefono, "[0-9]"))
            {
                _telefono = telefono;
            } else {
                throw new ArgumentException("Telefono a usar contiene caracteres invalidos.");
            }

            if (esEmailValido(email))
            {
                _email = email;
            } else {
                throw new ArgumentException("Formato de email a usar contiene caracteres invalidos.");
            }
            
        }

        public string Nombre => _nombre;

        public string Apellido => _apellido;

        public string Telefono => _telefono;

        public string Email => _email;
        
        bool esEmailValido(string stringTesteado)
        {
            // Retorna true si la string proporcionada tiene el formato correcto de un email.
            return Regex.IsMatch(stringTesteado, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
        }
    }
}