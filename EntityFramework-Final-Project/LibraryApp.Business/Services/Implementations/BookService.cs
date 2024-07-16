using LibraryApp.Business.Services.Interfaces;
using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;
using LibraryApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Core.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public async Task CreateBookAsync(Book book)
        {
            await _bookRepository.Insert(book);
            await _bookRepository.CommitAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existData = await _bookRepository.GetAsync(book.Id);
            if (existData != null)
            {
                existData.Title = book.Title;
                existData.Description = book.Description;
                existData.PublishedYear = book.PublishedYear;
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            if (book != null)
            {
                _bookRepository.Delete(book);
                await _bookRepository.CommitAsync();
            }
            else
            {
                Console.WriteLine("Id dont exist!");
            }
        }

        public List<Book> FilterBooksByTitle(string title)
        {
            return _bookRepository.GetAll()
                .Where(b => b.Title.Contains(title))
                .ToList();
        }

        public List<Book> FilterBooksByAuthor(string authorName)
        {
            return _bookRepository.GetAll()
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Where(b => b.BookAuthors.Any(ba => ba.Author.Name.Contains(authorName)))
                .ToList();
        }
    }
}
