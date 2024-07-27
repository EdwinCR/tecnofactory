using Administrator.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Administrator.Authorization
{
	public class ValidateSessionAttribute : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userSession = context.HttpContext.Session.GetString("User");
            var dataUser = userSession == null ? new UsersVM() : JsonSerializer.Deserialize<UsersVM>(userSession);
            if (dataUser.Email == null)
            {
                context.Result = new RedirectResult("~/Acces/LoginUser");
            }

            base.OnActionExecuting(context);
        }
    }
}
