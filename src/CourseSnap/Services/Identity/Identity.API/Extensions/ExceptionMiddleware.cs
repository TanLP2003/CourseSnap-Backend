using Identity.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Identity.API.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
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
