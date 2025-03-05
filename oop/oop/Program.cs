using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        static void Main( string[] args )
        {
            // Создаем библиотеку
            Library library = new Library();

            // Создаем книги
            Book book1 = new Book( "1984", "George Orwell", "123456789" );
            Book book2 = new Book( "To Kill a Mockingbird", "Harper Lee", "987654321" );

            // Добавляем книги в библиотеку
            library.AddBook( book1 );
            library.AddBook( book2 );

            // Создаем читателя
            Reader reader = new Reader( "Alice" );

            // Читатель берет книгу
            reader.BorrowBook( book1 );
            reader.DisplayBorrowedBooks();

            // Читатель возвращает книгу
            reader.ReturnBook( book1 );
            reader.DisplayBorrowedBooks();

            // Отображаем все книги библиотеки
            library.DisplayBooks();

            Console.ReadKey();
        }
    }  
   
}
