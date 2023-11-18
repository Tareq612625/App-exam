using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App_Service.AuthorizationService
{
    public class SessionTimeoutMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionTimeoutMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            var s = context.Session;
            if (!context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            if (context.Session == null)
            {
                context.Response.Redirect("/Login/AppLogin"); // Redirect to login page
                return;
            }

            await _next(context);
        }
    }
   
    
}
