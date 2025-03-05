using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Reader( string name )
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook( Book book )
        {
            BorrowedBooks.Add( book );
            Console.WriteLine( $"{Name} borrowed \"{book.Title}\"." );
        }

        public void ReturnBook( Book book )
        {
            if ( BorrowedBooks.Remove( book ) )
            {
                Console.WriteLine( $"{Name} returned \"{book.Title}\"." );
            }
            else
            {
                Console.WriteLine( $"{Name} does not have \"{book.Title}\"." );
            }
        }

        public void DisplayBorrowedBooks()
        {
            Console.WriteLine( $"{Name}'s borrowed books:" );
            foreach ( var book in BorrowedBooks )
            {
                book.DisplayInfo();
            }
        }
    }
}
