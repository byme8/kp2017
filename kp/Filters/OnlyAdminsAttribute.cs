using kp.Business.Abstractions.Services;
using kp.Business.Errors;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

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
                Error.Throw(Errors.AcessDenied);
        }
    }
}