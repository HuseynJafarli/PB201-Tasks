using FileIO.Core.Models;

namespace FileIO.Business.Services.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);

        Product Get(int id);

        List<Product> GetAll();

        void Delete(int id);

    }
}
