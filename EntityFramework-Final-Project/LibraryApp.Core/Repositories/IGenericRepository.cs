namespace LibraryApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task Insert(T entity);
        void Delete(T entity);
        Task<T?> GetAsync(int id);
        IQueryable<T> GetAll();
        Task<int> CommitAsync();

    }
}
