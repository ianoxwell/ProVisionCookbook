using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

/// <summary>
/// Altered from https://www.atlanticbt.com/insights/google-auth-tutorial/
/// </summary>
namespace Pcb.Security.Authorisation
{
    public class GoogleAuthoriseAttribute : TypeFilterAttribute
    {
        public GoogleAuthoriseAttribute() : base(typeof(GoogleAuthoriseFilter)) { }
    }

    public class GoogleAuthoriseFilter : IAuthorizationFilter
    {
        public GoogleAuthoriseFilter()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                // Verify Authorization header exists
                var headers = context.HttpContext.Request.Headers;
                if (!headers.ContainsKey("Authorization"))
                {
                    context.Result = new ForbidResult();
                }
                var authHeader = headers["Authorization"].ToString();

                // Verify authorization header starts with bearer and has a token
                if (!authHeader.StartsWith("Bearer ") && authHeader.Length > 7)
                {
                    context.Result = new ForbidResult();
                }

                // Grab the token and verify through google. If verification fails, and exception will be thrown.
                var token = authHeader.Remove(0, 7);
                var validated = GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings()).Result;
            }
            catch (Exception)
            {
                context.Result = new ForbidResult();
            }
        }
    }

}
