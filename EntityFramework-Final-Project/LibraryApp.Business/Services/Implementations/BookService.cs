using LibraryApp.Business.Services.Interfaces;
using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;
using LibraryApp.Data.Repositories;

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

        //public async Task UpdateBookAsync(Book book)
        //{
        //    _bookRepository.Update(book);
        //    await _bookRepository.CommitAsync();
        //}

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
    }
}
