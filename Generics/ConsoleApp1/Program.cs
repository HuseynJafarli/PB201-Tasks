namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Cosmos" , "Carl Sagan" , 384);
            Book book2 = new Book("Fight Club", "Chuck Palahniuk", 200);
            Book book3 = new Book("No Longer Human", "Osamu Dazai", 120);
            Book book4 = new Book("Gambler", "Dostoyevski", 120);
            Book book5 = new Book("No Country for Old Men", "C.McCarty", 320);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            Console.WriteLine(book1.Code);


            //try
            //{
            //    Console.WriteLine(library.FindBookByCode("Fi2"));
            //}
            //catch (BookNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message); 
            //}

            //Book[] findedBooks = library.FindAllBooksByPageCountRange(100, 200);
            //Helper.ShowAllBooksInArray(ref findedBooks);



            //library.RemoveBookByCode("NO3");
            //library.ShowAllBooks();

            Book[] findedByName = library.FindAllBooksByName("No");
            Helper.ShowAllBooksInArray(ref findedByName);


        }
    }
}
