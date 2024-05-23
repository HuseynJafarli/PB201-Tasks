namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1 , "1984" , 15 , "Dystopia");
            Book book2 = new Book(2, "No Longer Human", 13, "Horror");
            Book book3 = new Book(3, "Cosmos", 17, "Science");
            Book book4 = new Book(4, "Fahrenheit", 16, "Dystopia");
            //Console.WriteLine(book2.Genre);

            Library library1 = new Library();
            library1.AddBook(book1);
            library1.AddBook(book2);
            library1.AddBook(book3);
            library1.AddBook(book4);
            //foreach (var book in library1.Books)
            //{
            //    Console.WriteLine(book.Id + " " + book.Name);
            //}

            foreach (var book in library1.GetFilteredBooks("Dystopia"))
            {
                Console.WriteLine(book.Name + " " + book.Genre);
            }
            Console.WriteLine(library1.GetBookByName("1984").Name);
            Console.WriteLine(library1.GetBookById(2).Name);
        }
    }
}
