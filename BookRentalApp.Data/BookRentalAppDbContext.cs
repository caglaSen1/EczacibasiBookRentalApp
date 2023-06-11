using BookRentalApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookRentalApp.Data
{
    public class BookRentalAppDbContext : DbContext
    {
        public BookRentalAppDbContext(DbContextOptions<BookRentalAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookRentalAppDbContext).Assembly);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookRental> BookRentals { get; set; }
    }
}
