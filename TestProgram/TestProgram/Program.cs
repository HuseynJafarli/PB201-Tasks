using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters;

namespace TestProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int cnt = 0;


            //Task 1

            //    bool isPrime = IsPrime(n);

            //    if (isPrime)
            //    {
            //        Console.WriteLine(n + " is a prime number.");
            //    }
            //    else
            //    {
            //        Console.WriteLine(n + " is a composite number.");
            //    }
            //}

            //static bool IsPrime(int n)
            //{
            //    if (n <= 1) return false;
            //    for (int i = 2; i <= Math.Sqrt(n); i++)
            //    {
            //        if (n % i == 0)
            //        {
            //            return false;
            //        }
            //    }
            //    return true;
            //}

            //Task 2
            while(n > 0)
            {
                n /= 10;
                cnt++;
            }
            Console.WriteLine(cnt);
        }

    }
}
