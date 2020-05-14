namespace Parcial
{
    public class ArticuloNoPerecedero : Articulo
    {
        public ArticuloNoPerecedero() {}

        public ArticuloNoPerecedero(string nombre, decimal precio, long stock) : base(nombre, precio, stock) {}

        public ArticuloNoPerecedero(string nombre, char categoria, decimal precio, long stock) : base(nombre, categoria, precio, stock) {}
    }
}