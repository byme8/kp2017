using kp.Business.Errors;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kp.WebApi.Filters
{
    public class OnlyDatabaseAdminsAttribute : OnlyAdminsAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!this.UserService.IsDatabaseAdmin(this.Token.User.Id))
                Error.Throw(Errors.AcessDenied);
        }
    }
}