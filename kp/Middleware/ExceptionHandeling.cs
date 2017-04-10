using kp.Entities.Exceptions;
using kp.WebApi.Models.Responce;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
