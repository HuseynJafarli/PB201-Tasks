using ProductERP.Business.Dtos;
using ProductERP.Business.Services.Implementions;
using ProductERP.Business.Services.Interfaces;

namespace Product.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductServices productServices = new ProductService();
            ProductCreateDto productCreateDto = new ProductCreateDto("AS", 1500, 2000);
            productServices.Create(productCreateDto);


            Console.WriteLine("====================");

            Console.WriteLine(productServices.Get(1).Name);

        }
    }
}