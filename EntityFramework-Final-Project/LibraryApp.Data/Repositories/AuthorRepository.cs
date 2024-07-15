using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;

namespace LibraryApp.Data.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository 
    { 
    }
}
