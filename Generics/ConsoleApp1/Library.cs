namespace ConsoleApp1
{
    public class Library
    {
        private Book[] books = [];

        public void AddBook(Book book)
        {
            Helper.AddItemToArray(ref books, book);
        }

        public Book[] FindAllBooksByName(string name)
        {
            Book[] booksByName = [];
            foreach (Book book in books)
            {
                if (book.Name.Contains(name))
                {
                    Helper.AddItemToArray(ref booksByName, book);
                }
            }
            return booksByName;
        }

        public Book FindBookByCode(string code)
        {
            code = code.ToUpper();
            foreach (Book book in books)
            {
                if(book.Code == code)
                {  
                    return book;
                }
            }
            throw new BookNotFoundException(code);
        }

        public Book[] FindAllBooksByPageCountRange(int minPage , int maxPage)
        {
            if (minPage < 0 || maxPage < 0 || minPage > maxPage)
            {
                throw new ArgumentOutOfRangeException("Page range must be non-negative and minimum cannot be greater than maximum.");
            }
            Book[] booksByPage = [];
            foreach (Book book in books) 
            {
                if(book.PageCount >= minPage && book.PageCount <= maxPage)
                {
                    Helper.AddItemToArray(ref booksByPage, book);
                }
            }
            return booksByPage;
        }

        public void RemoveBookByCode(string code)
        {
            code = code.ToUpper();
            Book[] temporaryBooks = [];
            bool bookRemoved = false;
            foreach (Book book in books)
            {
                if(book.Code != code)
                {
                    Helper.AddItemToArray(ref temporaryBooks, book);
                }
                else
                {
                    bookRemoved = true;
                }
            }
            if (bookRemoved)
            {
                books = temporaryBooks;
            }
            else
            {
                //BookNotFound exception can be used too.
                Console.WriteLine($"Error: Book with code '{code}' not found. No book removed.");
            }
        }

        public void ShowAllBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
