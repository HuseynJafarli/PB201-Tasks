namespace Methods
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine(DifferenceBetweenOddAndEven(1, 2, 34, 5, 80, 84, 23));
            //Console.WriteLine(ReverseString("abc"));
            //Console.WriteLine(IsPalindrome("kabab"));
            var arr = new int[] { 1, 12, 3, 4, 4, 6, 1, 9, 12 };
            var uniqueElements = ReturnUnique(arr);

            foreach (var element in uniqueElements)
            {
                Console.WriteLine(element);
            }
        }
        static int DifferenceBetweenOddAndEven(params int[] arr)
        {
            int sumEven = 0, sumOdd = 0;
            foreach (var num in arr)
            {
                if(num % 2 == 0)
                {
                    sumEven += num;
                }
                else
                {
                    sumOdd += num;
                }
            }
            return sumEven - sumOdd;
        }
        static string ReverseString(string s)
        {
            string ss = "";
            for (int i = s.Length-1; i >= 0; i--)
            {
                ss += s[i];
            }
            return ss;
        }
        static double CalculateArea(int radius)
        {
            double areaCircle = 2 * 3.54 * radius;
            return areaCircle;
        } 
        static int CalculateArea(int a , int b)
        {
            int areaRectangle = a * b;
            return areaRectangle;
        }
        static bool IsPalindrome(string s)
        {
            bool isPalindrome = false;
            if(s == ReverseString(s))
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }
        public static int[] ConcatArray(int[] nums)
        {
            int[] result = new int[2 * nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[i + nums.Length] = nums[i];
            }
            return result;
        }
        public static int CountNumbers(int target, int[] numbers)
        {
            int count = 0;
            foreach (var number in numbers)
            {
                if (number >= target)
                {
                    count++;
                }
            }
            return count;
        }
        public static int[] ReturnUnique(int[] nums)
        {
            int nonZero = 0;
            for (int i = 0;i < nums.Length;i++)
            {
                bool used = false;
                
                for(int j = 0;j < i;j++)
                {
                    if (nums[j] == nums[i])
                    {
                        used = true; 
                        break;
                    }
                }
                if (used)
                {
                    nums[i] = 0;
                }
                else
                {
                    nonZero++;
                }
            }
            int[] filteredArr = new int[nonZero];
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if(nums[i] != 0)
                {
                    filteredArr[i] = nums[i];
                }
            }
            return filteredArr;
        }
    }
}
