using System;

namespace SegundoEjercicioOOP
{
    public class Libro
    {
        /*
            Para ello, crear la clase Libro, cuyos
            atributos son el titulo, el autor, el número de paginas y la calicación que le damos entre 0 y 10.
            Crear los métodos típicos para poder modicar y obtener los atributos si tienen sentido. 
            
            */
        private string Title { get; set; }
        private string Author { get; set; }
        private uint NumberOfPages { get; set; }
        private byte Rating { get; set; }
        
        public Libro(string title, string author, uint pagenumber, byte rating)
        {
            Title = title;
            Author = author;
            NumberOfPages = pagenumber;
            Rating = rating;
        }
        
        public string GetTitle => Title;

        public string GetAuthor => Author;

        public uint GetNumberOfPages => NumberOfPages;

        public byte GetRating => Rating;

        protected bool Equals(Libro other)
        {
            return Title == other.Title && Author == other.Author && NumberOfPages == other.NumberOfPages && Rating == other.Rating;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Libro) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, NumberOfPages, Rating);
        }
    }
}