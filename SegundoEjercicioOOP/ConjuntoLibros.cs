using System;
using System.Linq;
using System.Text;

namespace SegundoEjercicioOOP
{
    public class ConjuntoLibros
    {
        /*    Crear una clase ConjuntoLibros, que almacena un conjunto de libros (con un
            array de un tamaño fijo). Se pueden añadir libros que no existan (siempre que haya espacio),
            eliminar libros por título o autor, mostrar por pantalla los libros con la mayor y menor calicación
            dada y, por último, mostrar un contenido de todo el conjunto. */

        private Libro[] _libros;

        public ConjuntoLibros()
        {
            _libros = new Libro[5];
        }

        public Libro AddBook(Libro libro)
        {
            if (IsEmpty() || !_libros.Contains(libro) && !isFull())
            {
                for (var i = 0; i < _libros.Length; i++)
                {
                    if (_libros[i] == null)
                    {
                        _libros[i] = libro;
                        return _libros[i];
                    }
                }
            }

            return null;
        }

        public Libro AddBook(string title, string author, uint numberOfPages, byte rating)
        {

            return AddBook(new Libro(title, author, numberOfPages, rating));
        }

        public Libro DeleteBook(Libro book)
        {
            Libro deletedBook = book;
            
            if (!IsEmpty())
            {
                for (var i = 0; i < _libros.Length; i++)
                {
                    if (_libros[i] != null)
                    {
                        if (_libros[i].GetAuthor == book.GetAuthor || _libros[i].GetTitle == book.GetTitle)
                        {
                            _libros[i] = null;
                            return deletedBook;
                        }
                    }
                }
            }
            
            return null;
        }

        public Libro DeleteBookByAuthor(string author)
        {

            return DeleteBook(new Libro("randomtitle", author, 1, 1));
        }

        public Libro DeleteBookByTitle(string title)
        {
            return DeleteBook(new Libro(title, "randomAuthor", 1, 1));
        }
        
        public bool IsEmpty()
        {
            for (var i = 0; i < _libros.Length; i++)
            {
                if (_libros[i] != null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isFull()
        {
            for (var i = 0; i < _libros.Length; i++)
            {

                if (_libros[i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        public string GetBookWithHighestRating()
        {

            Array.Sort(_libros, (primerLibro, segundoLibro) => primerLibro.GetRating.CompareTo(segundoLibro.GetRating));
            Array.Reverse(_libros);

            return _libros[0].GetTitle;
        }

        public string GetBookWithLowestRating()
        {

          Array.Sort(_libros, (primerLibro, segundoLibro) => primerLibro.GetRating.CompareTo(segundoLibro.GetRating));
          
            return _libros[0].GetTitle;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");

            sb.Append("Stored books: ");
            
            for (var i = 0; i < _libros.Length; i++)
            {
                if (_libros[i] != null)
                {
                    sb.Append($"\n\t{i + 1} - {_libros[i].GetTitle} by {_libros[i].GetAuthor} is {_libros[i].GetNumberOfPages} pages long");
                    sb.Append($" and my personal rating for this book is: {_libros[i].GetRating}");
                }
            }

            return sb.ToString();
        }
    }
}