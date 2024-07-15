using LibraryApp.Core.Repositories;
using LibraryApp.Data.DAL;

namespace LibraryApp.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public LibraryDbContext _db;

        public GenericRepository() 
        {
            _db = new LibraryDbContext();
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }
    }
}
