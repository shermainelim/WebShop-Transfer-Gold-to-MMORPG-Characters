using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TeamFourA.Middlewares
{
    public class MyAuthMiddleware
    {
        private readonly RequestDelegate next;

        public MyAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string controller = (string)context.Request.RouteValues["controller"];
            string action = (string)context.Request.RouteValues["action"];

            if (controller == "Home")
            {
                string sessionId = context.Request.Cookies["sessionId"];
                if (sessionId == null)
                {
                    context.Response.Redirect("https://" +
                        context.Request.Host + "/Login/Index");
                    return;
                }
            }

            await next(context);
        }
    }
}
