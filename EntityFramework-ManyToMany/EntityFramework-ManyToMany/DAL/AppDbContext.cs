using EntityFramework_ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_ManyToMany.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarColor> CarColors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=CarManagementDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarColor>()
                .HasKey(cc => new { cc.CarId, cc.ColorId });

            modelBuilder.Entity<CarColor>()
                .HasOne(cc => cc.Car)
                .WithMany(c => c.CarColors)
                .HasForeignKey(cc => cc.CarId);

            modelBuilder.Entity<CarColor>()
                .HasOne(cc => cc.Color)
                .WithMany(c => c.CarColors)
                .HasForeignKey(cc => cc.ColorId);
        }
    }
}
