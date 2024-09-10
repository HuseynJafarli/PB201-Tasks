using API_INTRO.Configurations;
using API_INTRO.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace API_INTRO.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
