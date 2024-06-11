namespace ProductERP.Core.Models
{
    public class Product
    {
        private static int count;
        public int Id { get; set; }
        public string Name { get; set; }

        public double CostPrice { get; set; }

        public double SalePrice { get; set; }

        public Product()
        {
            count++;
            Id = count;
        }
    }
}