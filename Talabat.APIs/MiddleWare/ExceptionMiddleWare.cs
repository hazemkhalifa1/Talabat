using System.Text.Json;
using Talabat.APIs.Errors;

namespace Talabat.APIs.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate Next, ILogger<ExceptionMiddleWare> Logger, IHostEnvironment Env)
        {
            _next = Next;
            _logger = Logger;
            _env = Env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var Options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var ExceptionResponse = _env.IsDevelopment() ? new ApiExceptionResponse(500, ex.Message, ex.StackTrace)
                    : new ApiExceptionResponse(500);
                await context.Response.WriteAsJsonAsync(ExceptionResponse, Options);
            }
        }
    }
}
