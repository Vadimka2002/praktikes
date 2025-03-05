using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook( Book book )
        {
            Books.Add( book );
            Console.WriteLine( $"Added \"{book.Title}\" to the library." );
        }

        public void DisplayBooks()
        {
            Console.WriteLine( "Library books:" );
            foreach ( var book in Books )
            {
                book.DisplayInfo();
            }
        }
    }
}
