using ProductERP.Business.Dtos;

namespace ProductERP.Business.Services.Interfaces
{
    public interface IProductServices
    {
        void Create(ProductCreateDto productCreateDto);

        ProductGetDto Get(int id);

        List<ProductGetDto> GetAll();

        void Delete(int id);
    }
}
