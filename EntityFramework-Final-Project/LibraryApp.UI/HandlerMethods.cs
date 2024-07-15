using Azure.Core;
using LibraryApp.Core.Models;

namespace LibraryApp.UI
{
    public static class HandlerMethods
    {
        public static Author CreateAuthor()
        {
            Console.WriteLine("Enter Author Name:");
            var name = Console.ReadLine();
            Author author = new Author();
            author.Name = EnterValidString();
            return author;
        }
        public static string EnterValidString()
        {
            bool isValid = false;
            string input;
            do
            {
                input = Console.ReadLine();

                if (input != null)
                {
                    isValid = true;
                    return input;
                }
                else
                {
                    Console.WriteLine("Not a valid input!");
                }
            } while (!true);
            return input;
        }
        public static int EnterValidInt()
        {
            int number;
            bool isValidInput = false;

            do
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    isValidInput = true;
                    return number;
                }
                else
                {
                    Console.WriteLine("That's not a valid integer. Please try again.");
                }
            } while (!isValidInput);
            return number;
        }
    }
}
