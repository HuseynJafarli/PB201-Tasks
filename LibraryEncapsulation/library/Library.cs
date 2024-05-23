namespace library
{
    public class Library
    {
        public Book[] Books = Array.Empty<Book>();

        public void AddBook(Book book)
        {
            Array.Resize(ref Books, Books.Length + 1);
            Books[Books.Length - 1] = book;
        }
        public Book[] GetFilteredBooks(string genreName)
        {
            Book[] filteredBooks = Array.Empty<Book>();
            foreach (var book in Books)
            {
                if(book.Genre.ToLower() == genreName.ToLower())
                {
                    Array.Resize(ref filteredBooks , filteredBooks.Length+1);
                    filteredBooks[filteredBooks.Length - 1] = book;
                }
            }
            return filteredBooks;
        }
        public Book GetBookById(int id)
        {
            foreach (var book in Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book GetBookByName(string name)
        {
            foreach (var book in Books)
            {
                if (book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }


        public Book[] GetFilteredBooks(double minPrice, double maxPrice)
        {
            Book[] filteredBooks = Array.Empty<Book>();
            foreach (var book in Books)
            {
                if (book.Price >= minPrice && book.Price <= maxPrice)
                {
                    Array.Resize(ref filteredBooks, filteredBooks.Length + 1);
                    filteredBooks[filteredBooks.Length - 1] = book;
                }
            }
            return filteredBooks;
        }
    }
}
