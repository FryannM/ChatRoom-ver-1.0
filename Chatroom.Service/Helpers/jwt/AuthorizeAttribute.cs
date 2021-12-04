using Chatroom.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Chatroom.Service.Helpers.jwt
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if(user == null)
            {
                context.Result =
                    new JsonResult(new { message = "No autorizado" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
