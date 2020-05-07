using System;

namespace SegundoEjercicioOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Queremos mantener una colección de los libros que hemos ido leyendo, poniéndoles una
            calificación según nos haya gustado más o menos al leerlo. Para ello, crear la clase Libro, cuyos
            atributos son el titulo, el autor, el número de paginas y la calicación que le damos entre 0 y 10.
            Crear los métodos típicos para poder modicar y obtener los atributos si tienen sentido.
            Posteriormente, crear una clase ConjuntoLibros, que almacena un conjunto de libros (con un
            array de un tamaño fijo). Se pueden añadir libros que no existan (siempre que haya espacio),
            eliminar libros por título o autor, mostrar por pantalla los libros con la mayor y menor calicación
            dada y, por último, mostrar un contenido de todo el conjunto.
            Crear una clase PruebaLibros, que realice varias pruebas con las clases creadas. En concreto,
            pruebe a: crear dos libros, añadirlos al conjunto,
            eliminarlos por los dos criterios hasta que el conjunto esté vació, volver a añadir un libro y
            mostrar el contenido final. 
            */
            
            ConjuntoLibros libros = new ConjuntoLibros();

            libros.AddBook("Fahrenheit 451", "Ray Bradbury", 300, 10);
            libros.AddBook("Lord Of The Rings", "J. R. R. Tolkien", 600, 8);
            Libro codigoDeDaVinci = libros.AddBook("The Da-Vinci Code", "Dan Brown", 200, 9);
            Libro angelesYDemonios = libros.AddBook("Angels and Demons", "Dan Brown", 200, 7);
            Libro Inferno = libros.AddBook("Inferno", "Dan Brown", 200, 8);

            Console.WriteLine(libros.ToString());
            
            Console.WriteLine($"Favorite book: {libros.GetBookWithHighestRating()} ");
            Console.WriteLine($"Least favorite book: {libros.GetBookWithLowestRating()} ");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");


            libros.DeleteBookByTitle("Lord Of The Rings");
            libros.DeleteBook(codigoDeDaVinci);
            libros.DeleteBookByAuthor("Ray Bradbury");
            libros.DeleteBook(Inferno);
            libros.DeleteBook(angelesYDemonios);

            libros.AddBook("test", "test11", 1, 1);
            Console.WriteLine(libros.ToString());
            
        }
    }
}