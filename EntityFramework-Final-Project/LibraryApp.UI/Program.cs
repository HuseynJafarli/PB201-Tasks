using LibraryApp.Business.Services.Implementations;
using LibraryApp.Business.Services.Interfaces;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;

namespace LibraryApp.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IAuthorService authorService = new AuthorService();
            IBookService bookService = new BookService();
            IBorrowerService borrowerService = new BorrowerService();
            ILoanService loanService = new LoanService();
            Console.WriteLine("Welcome to the Library Management Console App!");

            while (true)
            {
                ShowMainMenu();

                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        ShowAuthorMenu(authorService);
                        GetChoice();
                        break;
                    case 2:
                        ShowBookMenu();
                        break;
                    case 3:
                        ShowBorrowerMenu();
                        break;
                    //case 4:
                    //    await DeleteAuthorAsync();
                    //    break;
                    //case 5:
                    //    await ListBooksAsync();
                    //    break;
                    //case 6:
                    //    await CreateBookAsync();
                    //    break;
                    //case 7:
                    //    await EditBookAsync();
                    //    break;
                    //case 8:
                    //    await DeleteBookAsync();
                    //    break;
                    //case 9:
                    //    await ListBorrowersAsync();
                    //    break;
                    //case 10:
                    //    await CreateBorrowerAsync();
                    //    break;
                    case 0:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1 - Author actions");
            Console.WriteLine("2 - Book actions");
            Console.WriteLine("3 - Borrower actions");
            Console.WriteLine("4 - BorrowBook");
            Console.WriteLine("5 - ReturnBook");
            Console.WriteLine("6 - Most borrowed book");
            Console.WriteLine("7 - Late borrowers");
            Console.WriteLine("8 - Borrowers with books");
            Console.WriteLine("9 - Filter books by title");
            Console.WriteLine("10 - Filter books by author");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

        }
        private static void ShowAuthorMenu(IAuthorService authorService)
        {
            Console.Clear();
            Console.WriteLine("Author Menu:");
            Console.WriteLine("1 - List all authors");
            Console.WriteLine("2 - Create new author");
            Console.WriteLine("3 - Edit author");
            Console.WriteLine("4 - Delete author");
            Console.WriteLine("0 - Back to main menu");
            Console.Write("Enter your choice: ");

            while (true)
            {
                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        authorService.GetAllAuthors().ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                        break;
                    case 2:
                        Author a = HandlerMethods.CreateAuthor();
                        authorService.CreateAuthorAsync(a);
                        Console.WriteLine("Author created successfully!");
                        break;
                    case 3:

                        //authorService.UpdateAuthorAsync();
                        //break;
                    case 4: 
                        var input = HandlerMethods.EnterValidInt();
                        authorService.DeleteAuthorAsync(input);
                        break;
                    case 0:
                        ShowMainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;

                }
            }
        }

        private static void ShowBookMenu()
        {
            Console.Clear();
            Console.WriteLine("Book Menu:");
            Console.WriteLine("1 - List all books");
            Console.WriteLine("2 - Create new book");
            Console.WriteLine("3 - Edit book");
            Console.WriteLine("4 - Delete book");
            Console.WriteLine("0 - Back to main menu");
            Console.Write("Enter your choice: ");
        }

        private static void ShowBorrowerMenu()
        {
            Console.Clear();
            Console.WriteLine("Borrower Menu:");
            Console.WriteLine("1 - List all borrowers");
            Console.WriteLine("2 - Create new borrower");
            Console.WriteLine("3 - Edit borrower");
            Console.WriteLine("4 - Delete borrower");
            Console.WriteLine("0 - Back to main menu");
            Console.Write("Enter your choice: ");
        }


        private static int GetChoice()
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
