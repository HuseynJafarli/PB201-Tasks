using EntityORM_1_BookTask.DAL;
using EntityORM_1_BookTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityORM_1_BookTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreateGenre(new Genre { Name = "Sci-Fi" });
            //CreateGenre(new Genre { Name = "Philosophy" });
            //CreateGenre(new Genre { Name = "Test" });
            //sci fi
            //CreateBook(new Book { Name = "Dune", CostPrice = 10.99m, Saleprice = 15.99m, GenreId = 1 });
            //CreateBook(new Book { Name = "Foundation", CostPrice = 8.99m, Saleprice = 12.99m, GenreId = 1 });
            //CreateBook(new Book { Name = "Neuromancer", CostPrice = 7.99m, Saleprice = 11.99m, GenreId = 1 });
            //philosophy
            //CreateBook(new Book { Name = "Crime and Punishment", CostPrice = 9.99m, Saleprice = 14.99m, GenreId = 2 });
            //CreateBook(new Book { Name = "The Brothers Karamazov", CostPrice = 12.99m, Saleprice = 18.99m, GenreId = 2 });
            //CreateBook(new Book { Name = "Notes from Underground", CostPrice = 6.99m, Saleprice = 10.99m, GenreId = 2 });
            //CreateBook(new Book { Name = "test's test", GenreId = 3});
            //DeleteBook(1);
            //DeleteGenre(3);
            var allBooks = GetAllBooks();
            foreach (var b in allBooks)
            {
                Console.WriteLine(b);
            }

            //var bookToUpdate = GetBookById(1); 
            //if (bookToUpdate != null)
            //{
            //    bookToUpdate.Saleprice = 13.99m;
            //    UpdateBook(bookToUpdate);
            //}

            //var genreToUpdate = GetGenreById(1); 
            //if (genreToUpdate != null)
            //{
            //    genreToUpdate.Name = "Science Fiction and Fantasy";
            //    UpdateGenre(genreToUpdate);
            //}

            

        }

        static void CreateBook(Book book)
        {
            AppDataContext appDataContext = new AppDataContext();
            appDataContext.Books.Add(book);
            appDataContext.SaveChanges();
        }
        static void CreateGenre(Genre genre)
        {
            AppDataContext appDataContext = new AppDataContext();
            appDataContext.Genres.Add(genre);
            appDataContext.SaveChanges();
        }
        static void DeleteBook(int id)
        {
            AppDataContext appDataContext = new AppDataContext();

            Book wantedBook = appDataContext.Books.Find(id);

            if (wantedBook != null)
            {
                appDataContext.Books.Remove(wantedBook);
                appDataContext.SaveChanges();
            }
        }
        static void DeleteGenre(int id)
        {
            AppDataContext appDataContext = new AppDataContext();

            Genre wantedGenre = appDataContext.Genres.Find(id);

            if (wantedGenre != null)
            {
                appDataContext.Genres.Remove(wantedGenre);
                appDataContext.SaveChanges();
            }
        }
        static Book GetBookById(int id)
        {
            AppDataContext appDataContext = new AppDataContext();

            return appDataContext.Books.Include("Genre").FirstOrDefault(x => x.Id == id);

        }
        static Genre GetGenreById(int id)
        {
            AppDataContext appDataContext = new AppDataContext();

            return appDataContext.Genres.FirstOrDefault(x => x.Id == id);

        }
        static List<Book> GetAllBooks()
        {
            AppDataContext appDataContext = new AppDataContext();
            return appDataContext.Books.Include("Genre").ToList();
        }
        static List<Genre> GetAllGenres()
        {
            AppDataContext appDataContext = new AppDataContext();
            return appDataContext.Genres.ToList();
        }

        static void UpdateBook(Book book)
        {
            AppDataContext appDataContext = new AppDataContext();

            var existingBook = appDataContext.Books.Find(book.Id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.CostPrice = book.CostPrice;
                existingBook.Saleprice = book.Saleprice;
                existingBook.GenreId = book.GenreId;
                appDataContext.SaveChanges();
            }

        }

        static void UpdateGenre(Genre genre)
        {
            AppDataContext appDataContext = new AppDataContext();

            var existingGenre = appDataContext.Genres.Find(genre.Id);
            if (existingGenre != null)
            {
                existingGenre.Name = genre.Name;

                appDataContext.SaveChanges();
            }

        }
    }
}
