using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    public class Cart
    {
        static List<Book> books = new List<Book>();
        static void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
