using Microsoft.AspNetCore.Diagnostics;
using Product.Domain.Exceptions;
using Product.Domain.Exceptions.Base;

namespace Product.API.Extensions
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
