using System;
using System.Web.Mvc;

namespace ProjetFinal.Authorization
{

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //public class AuthorizeAttribute : Attribute, IAuthorizationFilter{}

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            // Implement your custom authorization logic here
            // You can access User.Identity.IsAuthenticated to check if the user is authenticated

            // Check if the user is authenticated
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false; // User is not authenticated
            }

            // Check if the user has one of the allowed roles
            foreach (var role in allowedRoles)
            {
                if (httpContext.User.IsInRole(role))
                {
                    return true; // User is authorized
                }
            }

            return false; // User is not authorized for any allowed role
        }

   

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Redirect to a custom unauthorized page or perform other actions
            filterContext.Result = new HttpUnauthorizedResult("You are not authorized to access this resource.");
        }
    }
}