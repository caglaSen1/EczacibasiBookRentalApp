using BookRentalApp.Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BookRentalApp.Business
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
