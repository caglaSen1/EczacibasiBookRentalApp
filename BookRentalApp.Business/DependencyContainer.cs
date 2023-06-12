using BookRentalApp.Business.Interface;
using BookRentalApp.Business.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookRentalApp.Business
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IRentedBookService, RentedBookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
