using FileIO.Business.Services.Implementations;
using FileIO.Business.Services.Interfaces;
using FileIO.Core.Models;

namespace FileIO.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();

            
            Product newProduct = new Product
            {
                Id = 1,
                Name = "ayfon",
                CostPrice = 1000,
                SalePrice = 1500
            };
            productService.Create(newProduct);

            // Get product by id
            //Product product = productService.Get(1);
            //if (product != null)
            //{
            //    Console.WriteLine($"Retrieved Product: {product.Name}, Cost: {product.CostPrice}, Sale: {product.SalePrice}");
            //}
            //else
            //{
            //    Console.WriteLine("Product not found.");
            //}

            // Get all products
            List<Product> allProducts = productService.GetAll();
            Console.WriteLine($"Total Products: {allProducts.Count}");

            // Delete a product by id
            //productService.Delete(1);
            //Console.WriteLine("Product deleted.");
        }
    }
    
}
