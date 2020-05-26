using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamFourA.Db;
using TeamFourA.Models;
using TeamFourA.Services;

namespace TeamFourA.Controllers
{
    //shermaine
    public class RegisterController : Controller
    {
        protected Users users;
        protected Dictionary<string, StringTable> dict;
        private ShoppingContext dbcontext;
    

        public RegisterController(ShoppingContext dbcontext, Dictionary<string, StringTable>dict, Users user)
        {
             
            this.dbcontext = dbcontext;
            this.users = user;
            this.dict = dict;
        }

        public IActionResult Index(string locale)
        {
            StringTable stringTbl;

            if (locale != null)
            {
                dict.TryGetValue(locale, out stringTbl);
                Response.Cookies.Append("locale", locale);
            }
            else
                dict.TryGetValue(Request.Cookies["locale"], out stringTbl);

            ViewData["err"] = TempData["err"];
            ViewData["username"] = TempData["username"];
            ViewData["stringTbl"] = stringTbl;

            return View();
        }

        public IActionResult Register(string username, string hashPasswd)
        {
            StringTable stringTbl;
            dict.TryGetValue(Request.Cookies["locale"], out stringTbl);

            User user = users.GetUser(username, dbcontext);
            if (user != null)
            {
                TempData["err"] = stringTbl.username_taken;
                TempData["username"] = username;

                return RedirectToAction("Index");
            }

            users.AddUser(new User()
            {
                Username = username,
                Password = hashPasswd
            }, dbcontext);

            ViewData["username"] = username;
            ViewData["stringTbl"] = stringTbl;
            return View();
        }

        public IActionResult IsUsernameAvailable([FromBody] User inUser)
        {
            User user = users.GetUser(inUser.Username, dbcontext);

            return Json(user == null);
        }
    }
}
