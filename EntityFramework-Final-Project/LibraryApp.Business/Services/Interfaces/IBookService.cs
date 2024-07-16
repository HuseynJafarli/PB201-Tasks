using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
        List<Book> FilterBooksByTitle(string title);
        List<Book> FilterBooksByAuthor(string authorName);


    }
}
