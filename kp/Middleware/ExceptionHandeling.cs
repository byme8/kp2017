using System.Net;
using System.Text;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace kp.WebApi.Middleware
{
    public static class ExceptionHandeling
    {
        public static void UseExceptionHandling(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (BusinessException business)
                {
                    var message = Encoding.UTF8.GetBytes(business.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Body.Write(message, 0, message.Length);
                }
            });
        }
    }
}