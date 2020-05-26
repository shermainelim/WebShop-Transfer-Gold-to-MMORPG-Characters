using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamFourA.Middlewares;
using Microsoft.AspNetCore.Builder;


namespace TeamFourA.Extensions
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyAuthMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyAuthMiddleware>();

            return app;
        }
    }
}
