using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using kp.Entities.Exceptions;
using kp.Business.Abstractions.Services;

namespace kp.WebApi.Filters
{
    public class OnlyAdminsAttribute : AnyUserAttribute
    {
        public IUserService UserService
        {
            get;
            private set;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            this.UserService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
            if (!this.UserService.IsAdmin(this.Token.User.Id))
            {
                throw new BusinessException("Access denied");
            }
        }
    }
}
