using BookRentalApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<RentedBook>()
                .HasOne(rb => rb.Customer)
                .WithMany(c => c.RentedBooks)
                .HasForeignKey(rb => rb.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
    }
}
