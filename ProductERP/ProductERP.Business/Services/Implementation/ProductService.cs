using ProductERP.Business.Dtos;
using ProductERP.Business.Services.Interfaces;
using ProductERP.Core.Models;
using ProductERP.Data.DAL;

namespace ProductERP.Business.Services.Implementions
{
    public class ProductService : IProductServices
    {
        public void Create(ProductCreateDto productCreateDto)
        {
            ProductData.Products.Add(new Product()
            {
                Name = productCreateDto.Name,
                CostPrice = productCreateDto.costPrice,
                SalePrice = productCreateDto.salePrice,

            });
            Console.WriteLine("Created Successfully!");
        }

        public void Delete(int id)
        {
            Product? prod = ProductData.Products.Find(x => x.Id == id);
            ProductData.Products.Remove(prod);
        }

        public ProductGetDto Get(int id)
        {
            Product? prod = ProductData.Products.Find(x => x.Id == id);

            return new ProductGetDto(prod.Id, prod.Name, prod.SalePrice);
        }

        public List<ProductGetDto> GetAll()
        {
            return ProductData.Products.Select(x => new ProductGetDto(x.Id, x.Name, x.SalePrice)).ToList();
        }
    }
}