using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamFourA.Db;
using TeamFourA.Models;
using TeamFourA.Services;

namespace TeamFourA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShoppingContext _dbContext;
        private readonly ProductIds _productIds;

        public ProductsController(ShoppingContext shoppingContext, ProductIds productIds)
        {
            _dbContext = shoppingContext;
            _productIds = productIds;
        }

        public IActionResult Index(string productId)
        {
            // generate sessionId using guid
            var sessionId = HttpContext.Session.GetString("sessionId");

            if (sessionId == null)
                sessionId = Guid.NewGuid().ToString();

            // store sessionId in session
            HttpContext.Session.SetString("sessionId", sessionId);

            // if productId != null, add productId to session
            if (productId != null)
            {
                var preProductIds = HttpContext.Session.GetString("productIds");
                var postProductIds = _productIds.AddId(preProductIds, productId);
                HttpContext.Session.SetString("productIds", postProductIds);

                var badge = HttpContext.Session.GetString("Badge");

                if(badge == null)
                {
                    string[] ids = postProductIds.Split(";");
                    HttpContext.Session.SetString("Badge", ids.Length.ToString());

                } else
                {
                    string[] ids = postProductIds.Split(";");
                    HttpContext.Session.SetString("Badge", ids.Length.ToString());
                }
            }

            var model = new ProductsViewModel
            {
                Products = _dbContext.Products
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProductsViewModel model)
        {
            if (!String.IsNullOrEmpty(model.Text))
            {

                model.Products = _dbContext.Products
                    .Where(p => p.Name.Contains(model.Text) ||
                                p.Description.Contains(model.Text));
            }
            else
            {
                model.Products = _dbContext.Products;
            }

            return View(model);
        }

    }
}