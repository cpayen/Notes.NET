using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Web.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception).ConfigureAwait(false);

                // Throw the exception for other middlewares (Logging)
                throw;
            }
        }

        private async static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // 500 if unexpected
            var code = HttpStatusCode.InternalServerError;
            var title = "Server error";

            // 404 not found
            if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                title = "Not found";
            }

            var result = JsonConvert.SerializeObject(new { title, status = (int)code, error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }
}
