using System.Net;

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

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {

                    ErrorMessage = "Towarzyszu, wykryliśmy błąd. Postaramy się go jak najszybciej naprawić. Bywaj!"

                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
