using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using TeamFourA.Models;
using TeamFourA.Services;

namespace TeamFourA.Controllers
{
    //Shermaine
    public class HomeController : Controller
    {
        Dictionary<string, StringTable> dict;

        public HomeController(Dictionary<string, StringTable> dict)
        {
            this.dict = dict;
        }

        public IActionResult Index()
        {
            StringTable stringTbl;

            if (Request.Cookies["locale"] != null)
                dict.TryGetValue(Request.Cookies["locale"], out stringTbl);
            else
            {
                dict.TryGetValue("en", out stringTbl);
                Response.Cookies.Append("locale", "en");
            }

            ViewData["stringTbl"] = stringTbl;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
