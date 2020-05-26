using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TeamFourA.Db;
using TeamFourA.Models;
using TeamFourA.Services;

namespace TeamFourA.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingContext _dbContext;
        private Dictionary<string, int> dict = new Dictionary<string, int>();
        private ProductService productService = null;
        private readonly ProductIds _productIds;

        public ShoppingCartController(ShoppingContext shoppingContext, ProductIds productIds)
        {
            _dbContext = shoppingContext;
            productService = new ProductService(shoppingContext);
            _productIds = productIds;
        }
        public IActionResult Index(string productIds)
        {

            // if productIds != null or empty string, add productIds to session
            if (!String.IsNullOrEmpty(productIds))
                HttpContext.Session.SetString("productIds", productIds);

            //KyawThiha
            // get productidList from session
            //productIdList = "23084c0b-3207-4203-aa01-c1e6dba1d32e;

            string productIdList = HttpContext.Session.GetString("productIds");
           

            //check ProductId is null or not
            if (productIdList != null && productIdList.Length != 0)
            {
               
                List<ProductDetails> productDetailsList = productService.getProductDetailsList(productIdList);
                
                //pass productDetailsList
                ViewData["productDetailsList"] = productDetailsList;

                return View();
            }

            return View();
        }

        // (Joe) move myProductData to a Service
       
        [HttpPost]
        public IActionResult Checkout(string [] gameitem1, string[] productID, string[] nameItem, string [] qtyItem, string [] valueItem)
        {
            //(KyawThiha)
            // check if user is logged in
            // if user not logged in, redirect to Index() method of LoginController

            // get productIds from session
            string productIds = HttpContext.Session.GetString("productIds");
            List<ProductDetails> productList = productService.getProductDetailsList(productIds);


            string username = HttpContext.Session.GetString("username");

            if (username == null)
            {
                return RedirectToAction("Index", "Login");
            }

          
            //Shermaine- activating rethink to connect to game database and verifying game username 
            rethink db = new rethink();
            List<String> nonExistGameUserName = new List<String>();
            string gameusername = "";

            for (int i = 0; i < gameitem1.Length; i++)
            {
                bool result = true;
              
                if (nameItem[i].Equals("1000 Coins for NUS Team 4 MMORPG"))
                {
                    int qtyInt = Convert.ToInt32(qtyItem[i]);
                    int totalcoins = qtyInt * 1000;
                    result = db.Update(gameitem1[i], totalcoins);

                }

                if (result == false)
                {
                    nonExistGameUserName.Add(gameitem1[i]);
                    string errormsg = gameitem1[i] + " Game Username does not exist!";
                    HttpContext.Session.SetString("Error", errormsg);
                    return RedirectToAction("Index", "ShoppingCart");

                }
                else
                {
                    //update successfully
                    gameusername = gameitem1[i];
                    HttpContext.Session.SetString("Error", "");
                }
            }

            //call the service to add data to db
            productService.purchasedService(productList, username, gameusername);

            //clear productIds from session
            HttpContext.Session.SetString("productIds", "");
            HttpContext.Session.SetString("Badge", "0");

            // redirect user to Index() method of PurchasesController
            return RedirectToAction("Index", "Purchases");

        }

        public IActionResult RemoveItem(string productId)
        {

            //Shermaine- link to html view
            if (productId != null)
            {
                Debug.WriteLine("product id in remove item method is: {0}",productId);
                var ProductIds = HttpContext.Session.GetString("productIds");
                string[] proId = ProductIds.Split(";");
                ArrayList postIds= new ArrayList() ;
                Debug.WriteLine("pre Productids in remove item method is: {0}", ProductIds);
                foreach (var id in proId)
                {
                    if (!String.Equals(id,productId))
                    {
                        Debug.WriteLine("AppendingID {0}",id);
                        postIds.Add(id);
                    }
                }
                Debug.WriteLine("postIDs string array is {0}",postIds);

                StringBuilder builder = new StringBuilder();
                foreach (var value in postIds)
                {
                    Debug.WriteLine("value in postID {0}", value);

                    builder.Append(value);
                    builder.Append(';');
                }
                if(builder.Length != 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                Debug.WriteLine("stringbuilder is {0}", builder);
                var postProductIds = builder.ToString();
                Debug.WriteLine("post productIDs in remove item method is: {0}", postProductIds);
                HttpContext.Session.SetString("productIds", postProductIds);

                //Badge to add counter to cart
                var badge = HttpContext.Session.GetString("Badge");

                if (badge == null)
                {
                    string[] ids = postProductIds.Split(";");
                    HttpContext.Session.SetString("Badge", ids.Length.ToString());

                }
                else
                {
                    string[] ids = postProductIds.Split(";");
                    HttpContext.Session.SetString("Badge", ids.Length.ToString());
                }
            }
           
            return RedirectToAction("Index","ShoppingCart");
        }

        public IActionResult AddOneItem(string productId)
        {
            //shermaine-link to html view

            if (productId != null)
            {
                Debug.WriteLine("product id in add one item method is: {0}", productId);
                var ProductIds = HttpContext.Session.GetString("productIds");
                string[] proId = ProductIds.Split(";");
                ArrayList postIds = new ArrayList();
                Debug.WriteLine("pre Productids in add one item method is: {0}", ProductIds);
                foreach (var id in proId)
                { 
                        postIds.Add(id);
                }
                postIds.Add(productId);
                Debug.WriteLine("postIDs string array is {0}", postIds);

                StringBuilder builder = new StringBuilder();
                foreach (var value in postIds)
                {
                    Debug.WriteLine("value in postID {0}", value);

                    builder.Append(value);
                    builder.Append(';');
                }
                if (builder.Length != 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                Debug.WriteLine("stringbuilder is {0}", builder);
                var postProductIds = builder.ToString();
                Debug.WriteLine("post productIDs in add one item method is: {0}", postProductIds);
                HttpContext.Session.SetString("productIds", postProductIds);

            }

            return RedirectToAction("Index", "ShoppingCart");
        }
        public IActionResult MinusOneItem(string productId)
        {
            //shermaine-link to html view

            if (productId != null)
            {
                Debug.WriteLine("product id in minus one item method is: {0}", productId);
                var ProductIds = HttpContext.Session.GetString("productIds");
                string[] proId = ProductIds.Split(";");
                ArrayList postIds = new ArrayList();
                Debug.WriteLine("pre Productids in minus one item method is: {0}", ProductIds);
                int count = 0;
                foreach (var id in proId)
                {
                    if (count == 0 && String.Equals(id, productId))
                    {
                        count += 1;
                        continue;
                    }
                    postIds.Add(id);
                }
                Debug.WriteLine("postIDs string array is {0}", postIds);

                StringBuilder builder = new StringBuilder();
                foreach (var value in postIds)
                {
                    Debug.WriteLine("value in postID {0}", value);

                    builder.Append(value);
                    builder.Append(';');
                }
                if (builder.Length != 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                Debug.WriteLine("stringbuilder is {0}", builder);
                var postProductIds = builder.ToString();
                Debug.WriteLine("post productIDs in remove item method is: {0}", postProductIds);
                HttpContext.Session.SetString("productIds", postProductIds);

            }

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
   
}