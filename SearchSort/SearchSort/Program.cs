using System.Runtime.Intrinsics.X86;

namespace SearchSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1

            //int first = Convert.ToInt32(Console.ReadLine());
            //int last = Convert.ToInt32(Console.ReadLine());
            //int cnt = 0;
            //for (int i = first; i <= last; i++)
            //{
            //    if(i % 2 == 1)
            //    {
            //        cnt++;
            //    }
            //}
            //Console.WriteLine(cnt);


            //Task 2

            string str = "Code Academy";
            str = str.ToLower();
            char curr;
            int cnt;

            for (int i = 0; i < str.Length; i++)
            {
                curr = str[i];

                if (!char.IsLetter(curr))
                {
                    continue;
                }

                bool used = false;
                for (int j = 0; j < i; j++)
                {
                    if (str[j] == curr)
                    {
                        used = true;
                        break;
                    }
                }

                if (used)
                {
                    continue;
                }

                cnt = 0;
                foreach (char ch in str)
                {
                    if (ch == curr)
                    {
                        cnt++;
                    }
                }
                Console.WriteLine($"{str[i]} -- {cnt}");
            }



        }
    }
}
