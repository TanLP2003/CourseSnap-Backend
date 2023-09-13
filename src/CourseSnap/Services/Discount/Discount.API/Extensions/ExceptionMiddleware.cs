using Discount.Domain.Exceptions;
using Discount.Domain.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace Discount.API.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>().Error as BaseException;

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
