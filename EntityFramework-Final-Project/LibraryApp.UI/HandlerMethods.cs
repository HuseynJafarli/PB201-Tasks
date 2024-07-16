using Azure.Core;
using LibraryApp.Core.Models;

namespace LibraryApp.UI
{
    public static class HandlerMethods
    {
        public static Author CreateAuthor()
        {
            Author author = new Author();
            Console.WriteLine("Enter Author Name:");
            author.Name = EnterValidString();
            return author;
        }
        public static Book CreateBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter Book Title:");
            book.Title = EnterValidString();
            Console.WriteLine("Enter Book Description:");
            book.Description = EnterValidString();
            Console.WriteLine("Enter Book's Publish Year");
            book.PublishedYear = GetChoice();
            return book;
        }
        public static Borrower CreateBorrower()
        {
            Borrower borrower = new Borrower();
            Console.WriteLine("Enter Borrower Name:");
            borrower.Name = EnterValidString();
            Console.WriteLine("Enter Borrower's Email:");
            borrower.Email = EnterValidString();
            return borrower;
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

        public static int GetChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("Enter your choice: ");
            }
            return choice;
        }

    }
}
