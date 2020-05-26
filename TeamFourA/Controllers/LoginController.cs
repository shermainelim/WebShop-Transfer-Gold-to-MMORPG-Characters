using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TeamFourA.Services;
using TeamFourA.Models;
using TeamFourA.Db;

namespace TeamFourA.Controllers
{
    //shermaine
    public class LoginController : Controller
    {
        protected Users users;
        protected Dictionary<string, StringTable> dict;
        private ShoppingContext dbcontext;
        public LoginController(ShoppingContext dbcontext, Dictionary<string, StringTable> dict, Users users)
        {
            this.dict = dict;
            this.users = users;
            this.dbcontext = dbcontext;

        }

        public IActionResult Index(string locale)
        {
            StringTable stringTbl;
            if (locale != null)
            {
                dict.TryGetValue(locale, out stringTbl);
                Response.Cookies.Append("locale", locale);
            }
            else if (Request.Cookies["locale"] != null)
                dict.TryGetValue(Request.Cookies["locale"], out stringTbl);
            else
            {
                dict.TryGetValue("en", out stringTbl);
                Response.Cookies.Append("locale", "en");
            }

            ViewData["err"] = TempData["err"];
            ViewData["StringTbl"] = stringTbl;
            return View();
        }

        public IActionResult Login([FromServices] Users users, string username, string hashPasswd)
        {
            StringTable stringTbl;

            dict.TryGetValue(Request.Cookies["locale"], out stringTbl);
            //string pass = "hello";
            User user = users.AuthenticateUser(username, hashPasswd, dbcontext);
            if (user==null)
            {
                TempData["err"] = stringTbl.loginfail;
                return RedirectToAction("Index");
            }

            Response.Cookies.Append("sessionId", Guid.NewGuid().ToString(),
                new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddSeconds(30)
                });

            HttpContext.Session.SetString("username", username);

            TempData["username"] = username;
            return RedirectToAction("Index", "Home");
        }
    }
}
