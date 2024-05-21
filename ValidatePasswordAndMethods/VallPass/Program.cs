using System.Runtime.Serialization.Json;

namespace VallPass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidatePassword("Salam_123"));
            string s = "  sal am  ";
            Console.WriteLine(StringReplace(s , 'a' , 'e'));
            //Console.WriteLine(s.Substring(1, 3));
            Console.WriteLine(StringSubstring(s, 1 , 3));
            //Console.WriteLine(s.Trim());
            Console.WriteLine(StringTrim(s));
        }

        static bool ValidatePassword(string password)
        {
            if (password.Length >= 8) 

                if (char.IsUpper(password[0]))
                
                    if (password.Any(char.IsDigit))
                    
                        if (password.Any(char.IsPunctuation))
                        
                            return true;
            return false;
        }
        static string StringReplace(string str ,char oldChar , char newChar)
        {
            string newString = "";
            for(int i = 0; i < str.Length; i++) 
            {
                if (str[i] != oldChar)
                {
                    newString += str[i];
                }
                else
                {
                    newString += newChar;
                }
            }
            return newString;
        }
        static string StringSubstring(string str ,int a , int b)
        {
            string newString = "";
            for (int i = a; i <= b; i++)
            {
                newString += str[i];
            }
            return newString;
        }
        static string StringTrim(string str)
        {
            int endIndex = 0;
            int startIndex = 0;
            bool isFound = false;
            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {

                if (!char.IsWhiteSpace(str[i]))
                {
                    if (!isFound)
                        startIndex = i;
                        isFound = true;
                }
                if (!char.IsWhiteSpace(str[i]))
                {
                    endIndex = i;
                }

            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                newString += str[i];
            }
            return newString ;

        }
    }
}
