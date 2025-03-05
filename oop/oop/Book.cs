using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book( string title, string author, string isbn )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public void DisplayInfo()
        {
            Console.WriteLine( $"Title: {Title}, Author: {Author}, ISBN: {ISBN}" );
        }
    }
}
