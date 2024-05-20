namespace Methodss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReturnSumOfEvenTillTarget(10));
            PrintSumOfEvenTillTarget(10);
            Console.WriteLine(DeleteSpaces("  Code  Academy   "));
            PrintFirst("% b %Co de Acade % my ");
        }
        static int ReturnSumOfEvenTillTarget(int x)
        {
            int sumEven = 0;
            for (int i = 0; i < x; i++)
            {
                if (i % 2 == 0)
                {
                    sumEven += i;
                }
            }
            return sumEven;
        }
        static void PrintSumOfEvenTillTarget(int x)
        {
            int sumEven = 0;
            for (int i = 0; i < x; i++)
            {
                if (i % 2 == 0)
                {
                    sumEven += i;
                }
            }
            Console.WriteLine(sumEven);
        }
        static string DeleteSpaces(string s)
        {
            string result = "";
            foreach (char c in s)
            {
                if(c != ' ')
                {
                    result += c;
                }
            }
            return result;
        }
        static void PrintFirst(string s)
        {
            char prev = '\0';  

            for (int i = 0; i < s.Length; i++)
            {
                char curr = s[i];
                if ((i == 0 || (int)prev < 65 || ((int)prev > 90 && (int)prev < 97) || (int)prev > 122))
                {
                    if ((int)curr >= 65 && (int)curr <= 90 || (int)curr >= 97 && (int)curr <= 122)
                    {
                        Console.WriteLine(curr);
                    }
                }

                prev = curr;
            }
        }

    }
}
