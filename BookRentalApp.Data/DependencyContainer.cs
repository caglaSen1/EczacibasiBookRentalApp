using BookRentalApp.Data.Interface;
using BookRentalApp.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRentalApp.Data
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BookRentalAppDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("BookRentalApp.Data")));
            services.AddScoped<DbContext>(provider => provider.GetService<BookRentalAppDbContext>());

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRentedBookRepository, RentedBookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
