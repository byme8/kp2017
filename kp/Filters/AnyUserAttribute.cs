using System;
using kp.Business.Abstractions.Services;
using kp.Business.Errors;
using kp.Domain.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kp.WebApi.Filters
{
    public class AnyUserAttribute : ActionFilterAttribute
    {
        public Token Token
        {
            get;
            private set;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!Guid.TryParse(context.HttpContext.Request.Headers["UserToken"], out var tokenId))
                Error.Throw(Errors.AcessDenied);

            var tokenService = context.HttpContext.RequestServices.GetService(typeof(ITokenService)) as ITokenService;
            if (tokenService.IsExpired(tokenId))
                Error.Throw(Errors.TokenExpired);

            this.Token = tokenService.Get(tokenId);
        }
    }
}