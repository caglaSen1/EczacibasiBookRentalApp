using BookRentalApp.Data.Interface;
using BookRentalApp.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Data
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookRentalAppDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("BookRentalApp.Data")));
            services.AddScoped<DbContext>(provider => provider.GetService<BookRentalAppDbContext>());

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookRentalRepository, BookRentalRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
