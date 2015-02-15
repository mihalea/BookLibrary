using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        public String author;
        public String title, publisher;
        public String tags;

        public Book()
        {
            author = String.Empty;
            title = String.Empty;
            publisher = String.Empty;
            tags = String.Empty;
        }

    }
}
