using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace BookRentalApp.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(System.Exception e) 
            {
                _logger.LogError(e.Message);
                
                httpContext.Response.ContentType = "application/json";

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //  code : "500", "message": "hata", url:""

                var result = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = (int)HttpStatusCode.InternalServerError, 
                    message = "Error Occurred", url = httpContext.Request.Path.Value });

                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
