using BookRentalApp.Business.Dto.BookRental;
using BookRentalApp.Business.Interface;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Business
{
    public static class ServiceResultLogger 
    {
        public static ServiceResult<T> Succeeded<T>(T data, string message, int code, ILogger logger)
        {
            logger.LogInformation("Success: {Result} - {Message} - StatusCode: {StatusCode}", data, message, code);
            return ServiceResult<T>.Succeeded(data, message, code);
        }

        public static ServiceResult<T> Failed<T>(T data, string message, int code, ILogger logger)
        {
            logger.LogError("Failed: {Result} - {Message} - StatusCode: {StatusCode}", data, message, code);
            return ServiceResult<T>.Failed(data, message, code);
        }
    }

    
}