using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamFourA.Db;
using TeamFourA.Models;

namespace TeamFourA.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly ShoppingContext _dbContext;
        private readonly Users _users;

        public PurchasesController(ShoppingContext dbContext, Users users)
        {
            _dbContext = dbContext;
            _users = users;
        }

        public IActionResult Index()
        {
            var userInSession = HttpContext.Session.GetString("username");
            var userId = _users.GetUser(userInSession, _dbContext).OldId;
            var transactions = _dbContext.Transactions
                .Where(p => p.UserId == userId).ToList();

            return View(transactions);
        }

    }
}