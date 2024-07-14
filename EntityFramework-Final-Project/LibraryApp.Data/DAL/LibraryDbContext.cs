using LibraryApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.DAL
{
    public class LibraryDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> LoanItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=LibraryManagementAppDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("NVARCHAR");

            modelBuilder.Entity<Book>().Property(x => x.Description)
                .HasMaxLength(300)
                .HasColumnType("NVARCHAR");

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Borrower)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.BorrowerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookAuthor>().HasOne(x => x.Book).WithMany(x => x.BookAuthors);
            modelBuilder.Entity<BookAuthor>().HasOne(x => x.Author).WithMany(x => x.BookAuthors);

            modelBuilder.Entity<Author>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("NVARCHAR");

            modelBuilder.Entity<LoanItem>()
                .HasOne(x => x.Loan)
                .WithMany(x => x.LoanItems)
                .HasForeignKey(x=>x.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanItem>()
                .HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}
