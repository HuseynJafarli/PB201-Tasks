using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;

namespace LibraryApp.Data.Repositories
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
    }
}
