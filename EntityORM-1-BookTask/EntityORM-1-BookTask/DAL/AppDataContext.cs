using EntityORM_1_BookTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityORM_1_BookTask.DAL
{
    public class AppDataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
