using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Quizlo.API.Middlewares
{
    public class GlobalExceptionHandling
    {
        private readonly ILogger<GlobalExceptionHandling> logger;
        private readonly RequestDelegate next;

        public GlobalExceptionHandling(ILogger<GlobalExceptionHandling> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                httpContext.Response.ContentType = "application/json";

                
                var statusCode = (int)HttpStatusCode.InternalServerError;

                
                var error = new
                {
                    StatusCode = statusCode,
                    ErrorMessage = "Towarzyszu, wykryliśmy błąd. Postaramy się go jak najszybciej naprawić. Bywaj!"
                };

                
                httpContext.Response.StatusCode = statusCode;

               
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }
    }
}
