using FileIO.Business.Services.Interfaces;
using FileIO.Core.Models;
using System.Text.Json;

namespace FileIO.Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private string _filePath = "C:\\Users\\User\\Desktop\\PB201-Tasks\\FileIO-Json\\FileIO.Data\\Products.txt";

        public void Create(Product product)
        {
            List<Product> products = GetAll();
            products.Add(product);
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(_filePath, json);
        }

        public Product Get(int id)
        {
            List<Product> products = GetAll();
            return products.Find(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Product>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Product>();
            }

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

            if (products == null)
            {
                products = new List<Product>();
            }

            return products;
        }

        public void Delete(int id)
        {
            List<Product> products = GetAll();
            Product productToRemove = products.Find(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                string json = JsonSerializer.Serialize(products);
                File.WriteAllText(_filePath, json);
            }
        }
    }
}
