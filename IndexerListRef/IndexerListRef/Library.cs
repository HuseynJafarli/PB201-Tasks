namespace IndexerListRef
{
    public class Library
    {
        private List<Book> books = [];

        public Book this[int index] 
        {
            get { return books[index];}
            
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> FindAllBooksByName(string value)
        {
            value = value.Trim().ToLower();       
            return books.FindAll(book => book.Name.ToLower().Contains(value));
        }

        public Book FindBookByCode(string code)
        {
            
            var findedBook = books.Find(book => book.Code.ToLower() == code.ToLower());
            if (findedBook != null)
            {
                return findedBook;
            }
            else 
            {
                throw new NullReferenceException("Book could not be found");
            }
        }

        public void RemoveAllBooksByName(string value)
        {
            books.RemoveAll(book => book.Name.ToLower().Contains(value.ToLower()));
        }

        public List<Book> SearchBooks(string value)
        {
            value = value.Trim().ToLower();

            return books.FindAll(book =>
                book.Name.ToLower().Contains(value) ||
                book.AuthorName.ToLower().Contains(value) ||
                book.PageCount.ToString().Contains(value));
        }

        public List<Book> FindAllBooksByPageCountRange(int minPageCount, int maxPageCount)
        {
            return books.FindAll(book => book.PageCount >= minPageCount && book.PageCount <= maxPageCount);
        }

        public void RemoveBookByCode(string code)
        {
            var bookToRemove = books.Find(book => book.Code.ToLower() == code.ToLower());
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            else 
            {
                Console.WriteLine("Book code did not match with any book in library");
            }
        }
    }
}
