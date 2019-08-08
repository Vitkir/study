using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.Id = 1;

            ChangeId(book);
            Console.WriteLine(book.Id);
            Console.ReadKey();
        }
    static void ChangeId(Book book)
        {
            book.Id = -1;
        }
    }

}
