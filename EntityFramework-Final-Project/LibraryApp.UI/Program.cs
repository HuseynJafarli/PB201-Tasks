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

                int choice = HandlerMethods.GetChoice();

                switch (choice)
                {
                    case 1:
                        ShowAuthorMenu(authorService);
                        break;
                    case 2:
                        ShowBookMenu(bookService);
                        break;
                    case 3:
                        ShowBorrowerMenu(borrowerService);
                        break;
                    case 9:
                        Console.WriteLine("Enter the title to filter:");
                        string titleFilter = HandlerMethods.EnterValidString();
                        List<Book> filteredBooksByTitle = bookService.FilterBooksByTitle(titleFilter);
                        filteredBooksByTitle.ForEach(b => Console.WriteLine($"{b.Id} - {b.Title} ({b.PublishedYear})"));
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;
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
            Console.WriteLine("Welcome to Menu!");

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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Author Menu");
                Console.WriteLine("Author Menu:");
                Console.WriteLine("1 - List all authors");
                Console.WriteLine("2 - Create new author");
                Console.WriteLine("3 - Edit author");
                Console.WriteLine("4 - Delete author");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = HandlerMethods.GetChoice();

                switch (choice)
                {
                    case 1:
                        List<Author> authors = authorService.GetAllAuthors();
                        if (authors == null || authors.Count == 0)
                        {
                            Console.WriteLine("No Author found!");
                        }
                        else
                        {
                            authors.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Author newAuthor = HandlerMethods.CreateAuthor();
                        authorService.CreateAuthorAsync(newAuthor);
                        Console.WriteLine("Author created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Author> authorsToUpdate = authorService.GetAllAuthors();
                        if (authorsToUpdate == null || authorsToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Author found!");
                        }
                        else
                        {
                            authorsToUpdate.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                            Console.Write("Enter Id of the author to update: ");
                            int updateId = HandlerMethods.GetChoice();
                            var authorToUpdate = authorsToUpdate.FirstOrDefault(a => a.Id == updateId);
                            if (authorToUpdate != null)
                            {
                                Console.Write("Enter new name: ");
                                authorToUpdate.Name = HandlerMethods.EnterValidString();
                                authorService.UpdateAuthorAsync(authorToUpdate);
                                Console.WriteLine("Author updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Author not found!");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Author> authorsToDelete = authorService.GetAllAuthors();
                        if (authorsToDelete == null || authorsToDelete.Count == 0)
                        {
                            Console.WriteLine("No Author found!");
                        }
                        else
                        {
                            authorsToDelete.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                            Console.Write("Enter Id of the author to delete: ");
                            int deleteId = HandlerMethods.GetChoice();
                            authorService.DeleteAuthorAsync(deleteId);
                            Console.WriteLine("Author deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return; 
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }


        private static void ShowBookMenu(IBookService bookService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Book Menu:");
                Console.WriteLine("1 - List all books");
                Console.WriteLine("2 - Create new book");
                Console.WriteLine("3 - Edit book");
                Console.WriteLine("4 - Delete book");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = HandlerMethods.GetChoice();

                switch (choice)
                {
                    case 1:
                        List<Book> books = bookService.GetAllBooks();
                        if (books == null || books.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            books.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2: 
                        Book newBook = HandlerMethods.CreateBook();
                        bookService.CreateBookAsync(newBook);
                        Console.WriteLine("Book created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Book> booksToUpdate = bookService.GetAllBooks();
                        if (booksToUpdate == null || booksToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            booksToUpdate.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                            Console.Write("Enter Id of the book to update: ");
                            int updateId = HandlerMethods.GetChoice();
                            var bookToUpdate = booksToUpdate.FirstOrDefault(b => b.Id == updateId);
                            if (bookToUpdate != null)
                            {
                                Console.Write("Enter new title: ");
                                bookToUpdate.Title = HandlerMethods.EnterValidString();
                                Console.WriteLine("Enter new Description:");
                                bookToUpdate.Description = HandlerMethods.EnterValidString();
                                Console.WriteLine("Enter new Publish Year");
                                bookToUpdate.PublishedYear = HandlerMethods.GetChoice();
                                bookService.UpdateBookAsync(bookToUpdate);
                                Console.WriteLine("Book updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Book not found!");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Book> booksToDelete = bookService.GetAllBooks();
                        if (booksToDelete == null || booksToDelete.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            booksToDelete.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                            Console.Write("Enter Id of the book to delete: ");
                            int deleteId = HandlerMethods.GetChoice();
                            bookService.DeleteBookAsync(deleteId);
                            Console.WriteLine("Book deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }


        private static void ShowBorrowerMenu(IBorrowerService borrowerService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Borrower Menu:");
                Console.WriteLine("1 - List all borrowers");
                Console.WriteLine("2 - Create new borrower");
                Console.WriteLine("3 - Edit borrower");
                Console.WriteLine("4 - Delete borrower");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = HandlerMethods.GetChoice();

                switch (choice)
                {
                    case 1:
                        List<Borrower> borrowers = borrowerService.GetAllBorrowers();
                        if (borrowers == null || borrowers.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowers.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Borrower newBorrower = HandlerMethods.CreateBorrower();
                        borrowerService.CreateBorrowerAsync(newBorrower);
                        Console.WriteLine("Borrower created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Borrower> borrowersToUpdate = borrowerService.GetAllBorrowers();
                        if (borrowersToUpdate == null || borrowersToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowersToUpdate.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                            Console.Write("Enter Id of the borrower to update: ");
                            int updateId = HandlerMethods.GetChoice();
                            var borrowerToUpdate = borrowersToUpdate.FirstOrDefault(b => b.Id == updateId);
                            if (borrowerToUpdate != null)
                            {
                                Console.Write("Enter new name: ");
                                borrowerToUpdate.Name = HandlerMethods.EnterValidString();
                                Console.Write("Entewr new email: ");
                                borrowerToUpdate.Email = HandlerMethods.EnterValidString();
                                borrowerService.UpdateBorrowerAsync(borrowerToUpdate);
                                Console.WriteLine("Borrower updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Borrower not found!");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Borrower> borrowersToDelete = borrowerService.GetAllBorrowers();
                        if (borrowersToDelete == null || borrowersToDelete.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowersToDelete.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                            Console.Write("Enter Id of the borrower to delete: ");
                            int deleteId = HandlerMethods.GetChoice();
                            borrowerService.DeleteBorrowerAsync(deleteId);
                            Console.WriteLine("Borrower deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }


    }
}
