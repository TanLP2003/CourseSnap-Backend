using Microsoft.AspNetCore.Diagnostics;
using Payment.Domain.Exceptions;

namespace Payment.API.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(appErr =>
            {
                appErr.Run(async context =>
                {
                    var error = context.Features.Get<IExceptionHandlerFeature>().Error;

                    var exception = error is BaseException ? (BaseException)error : new BaseException(error.Message);

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = exception.StatusCode;

                    await context.Response.WriteAsync(new ErrorModel
                    {
                        Message = exception.Message,
                        StatusCode = exception.StatusCode
                    }.ToString());
                });
            });
        }
    }
}
