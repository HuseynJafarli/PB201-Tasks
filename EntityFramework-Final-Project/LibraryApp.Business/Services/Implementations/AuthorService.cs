using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;
using LibraryApp.Data.Repositories;

namespace LibraryApp.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _authorRepository.Insert(author);
            await _authorRepository.CommitAsync();

        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var existData = await _authorRepository.GetAsync(author.Id);
            if (existData != null)
            {
                existData.Name = author.Name;
            }
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await _authorRepository.GetAsync(authorId);
            if (author != null)
            {
                _authorRepository.Delete(author);
                await _authorRepository.CommitAsync();
            }
            else
            {
                Console.WriteLine("Id dont exist!");
            }
        }
    }
}
