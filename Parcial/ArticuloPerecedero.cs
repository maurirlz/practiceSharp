using System;

namespace Parcial
{
    public class ArticuloPerecedero : Articulo
    {
        private readonly DateTime _vencimiento; // readonly pq una vez q adquire esa fecha de vencimiento, no debe ser cambiada.
        public bool _estaVencido;
        public ArticuloPerecedero(string nombre, decimal precio, long stock, DateTime vencimiento) : base(nombre, precio, stock)
        {
            _vencimiento = vencimiento;
        }

        public ArticuloPerecedero(string nombre, char categoria, decimal precio, long stock, DateTime vencimiento) : base(nombre, categoria, precio, stock)
        {
            _vencimiento = vencimiento;
        }
        
        // Devuelve el vencimiento en un formato string para facil lectura.

        public string GetVencimiento => _vencimiento.ToString("ddMMyy");
        
        // Chequea si el producto esta vencido, si el producto vence el 25/12 y hoy es 26/12, 26/12 > 25/12, esto significa que esta vencido.

        public bool EstaVencido()
        {
            DateTime diaDeLaFecha = DateTime.Now;

            _estaVencido = diaDeLaFecha > _vencimiento;
            ;
            return _estaVencido;
        }
        
        // Sobreescritura de equals y hashcode.
        
        protected bool Equals(ArticuloPerecedero other)
        {
            return base.Equals(other) && _vencimiento == other._vencimiento;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ArticuloPerecedero) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _vencimiento);
        }
    }
}