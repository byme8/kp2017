using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using kp.Entities.Exceptions;

namespace kp.WebApi.Filters
{
    public class OnlyDatabaseAdminsAttribute : OnlyAdminsAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!this.UserService.IsDatabaseAdmin(this.Token.User.Id))
            {
                throw new BusinessException("Access denied");
            }
        }
    }
}
