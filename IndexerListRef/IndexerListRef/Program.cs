namespace IndexerListRef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Cosmos", "Carl Sagan", 384);
            Book book2 = new Book("Fight Club", "Chuck Palahniuk", 200);
            Book book3 = new Book("No Longer Human", "Osamu Dazai", 120);
            Book book4 = new Book("Gambler", "Dostoyevski", 120);
            Book book5 = new Book("No Country for Old Men", "C.McCarty", 320);

            //Console.WriteLine(book2.Code);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            //Console.WriteLine(library[3].ToString());

            //Console.WriteLine(library.FindAllBooksByName("No")[0].ToString());

            //try
            //{
            //    Console.WriteLine(library.FindBookByCode("aa"));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine(library.FindBookByCode("FI2"));

            //Console.WriteLine(library.SearchBooks("0")[0]);

            //library.RemoveAllBooksByName(book1.Name);
            //Checking if first element is removed - works.
            //Console.WriteLine(library[0]);


            //library.RemoveBookByCode(book1.Code);
            //Console.WriteLine(library[0]);


            //List<Book> finded = library.FindAllBooksByPageCountRange(100, 300);

            //foreach (var item in finded)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            
        }
    }
}
