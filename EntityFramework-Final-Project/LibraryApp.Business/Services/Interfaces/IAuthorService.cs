using LibraryApp.Core.Models;
using System.Collections.Generic;

namespace LibraryApp.Core.Services
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Task CreateAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int authorId);
    }
}
