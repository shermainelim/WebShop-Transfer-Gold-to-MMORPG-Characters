using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using TeamFourA.Models;

namespace TeamFourA.Db
{
    public class DBSeeder
    {
        public DBSeeder(ShoppingContext dbContext)
        {
            // (shermaine) seed database with products to sql

            Product product1 = new Product();
            product1.Name = "1000 Coins for Webshop_MVC_SQL MMORPG";
            product1.Description = "Buy 1000 coins to unlock the Ultimate God Hat and God Sword!";
            product1.Price = 50.00;
            product1.ImageURL = "coinslittlesweets.jpg";
            product1.Value = 1000;

            Product product2 = new Product();
            product2.Name = "The Unexpected Quest";
            product2.Description = "Travel to a whole new world and prove your wizardry prowess with forts and potions.";
            product2.Price = 50.00;
            product2.ImageURL = "quest.jpg";
            //change quantity
            //add button add to cart

            Product product3 = new Product();
            product3.Name = "Turnip Boy";
            product3.Description = "With the power of gardening, grow tools to solve plantastic puzzles and win treacherous battles!";
            product3.Price = 18.00;
            product3.ImageURL = "turnipboy.jpg";
            //change quantity
            //add button add to cart

            Product product4 = new Product();
            product4.Name = "Webshop_MVC_SQL MMORPG";
            product4.Description = "Free MMO Game, fight monsters, obtain the Ultimate God Hat and God Sword!";
            product4.Price = 0.00;
            product4.ImageURL = "mmo.jpg";
            //no quantity
            //add button add to cart

            Product product5 = new Product();
            product5.Name = "Greedy Goblins";
            product5.Description = "In this intense first-person shooter game, it’s a matter of survival! " +
                "Escape an old mansion infested with greedy goblins!";
            product5.Price = 20.00;
            product5.ImageURL = "goblin.jpg";
            //change quantity
            //add button add to cart

            Product product6 = new Product();
            product6.Name = "Errant Kingdom";
            product6.Description = "Enter a high fantasy world steeped in political intrigue; where magic touches the land and blood turns the wheels unseen.";
            product6.Price = 30.00;
            product6.ImageURL = "errant.jpg";
            //add quantity
            //add button add to cart

            dbContext.Add(product1);
            dbContext.Add(product2);
            dbContext.Add(product3);
            dbContext.Add(product4);
            dbContext.Add(product5);
            dbContext.Add(product6);
            dbContext.SaveChanges();
        }
    }
}
