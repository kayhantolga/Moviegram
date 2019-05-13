using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moviegram.Domain.Exceptions;
using Newtonsoft.Json;

namespace Moviegram.Application
{
    public class MoviegramExceptionHandler
    {
        private readonly RequestDelegate _next;

        public MoviegramExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            const HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (!(exception is MoviegramException moviegramException))
            {
                //TODO log this exception
                moviegramException = new MoviegramException()
                {
                    Id = Guid.NewGuid(),
                    DeveloperMessage = exception.Message + " inner: " +exception.InnerException?.Message,
                    UserFriendlyMessage = "Something Wrong",
                    Code = "99X99999",
                };
            }
            var result = JsonConvert.SerializeObject(moviegramException.ToPresentable());

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
