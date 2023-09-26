using System.Collections.Generic;

namespace LR4
{
    public class Book
    {
        public List<BookInfo> Books { get; set; } = new();
    }

    public class BookInfo
    { 
        public string Name { get; set; }
        public string Author { get; set; }
    }
}