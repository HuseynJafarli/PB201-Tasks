using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Biggest num algorithm - Task 1

            //int[] numbers = { 1, 5, 3 , 4 ,9 ,3 ,2, 7 , 11};
            //int max = -1000000;
            //int curr;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    curr = numbers[i];
            //    if (curr > max)
            //    {
            //        max = curr;
            //    }
            //}
            //Console.WriteLine(max);


            //Task 2
            int price = 0, cnt = 0;
            var product1 = new { Id = 190, Name = "Defter", Price = 1, StockCount = 111111 };
            var product2 = new { Id = 145, Name = "Kitab", Price = 10, StockCount = 890 };
            var product3 = new { Id = 637, Name = "Kompyuter", Price = 1955, StockCount = 53 };
            var product4 = new { Id = 1235, Name = "Telefon", Price = 1400, StockCount = 1348 };
            var products = new[] { product1, product2, product3, product4 };
            foreach (var product in products) { 
                
                if(product.Id % 2 == 1)
                {
                    price += product.Price;
                    cnt++;
                }

            }
            Console.WriteLine(price / cnt);
        }
    }
}
