using kp.Business.Abstractions.Services;
using kp.Business.Exceptions;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp.Domain.Data;

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
            {
                throw new BusinessException("You should be authorized.");
            }

            var tokenService = context.HttpContext.RequestServices.GetService(typeof(ITokenService)) as ITokenService;
            if (tokenService.IsExpired(tokenId))
            {
                throw new TokenExpiredException();
            }

            this.Token = tokenService.Get(tokenId);
        }
    }
}
