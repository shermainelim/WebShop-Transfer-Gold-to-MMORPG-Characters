using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamFourA.Db;

namespace TeamFourA.Models
{
    public class Users
    {
       
        public Users()
        {
            
        }

        public void AddUser(User user, ShoppingContext dbcontext)
        {
            //shermaine
            Debug.WriteLine("Register with password: {0}", user.Password);
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
        }

        
        public User AuthenticateUser(string Username, string Password, ShoppingContext dbcontext)
        {
            //shermaine

            User dbUser = dbcontext.Users
                .Where(x => x.Username == Username).FirstOrDefault();

            if (dbUser == null || dbUser.Password ==null)
            {
                return null;
            }


            Debug.WriteLine("Database pw: {0}", dbUser.Password);
            Debug.WriteLine("Entered pw:{0} ", Password);


            if (dbUser != null && dbUser.Password == Password)
            {
                return dbUser;
            }

            return null;

        }
        public User GetUser(string Username, ShoppingContext dbcontext)
        {
            //shermaine
            //User user = dbcontext.Users.Single(x => x.Username == Username); 
            User user = dbcontext.Users
               .Where(x => x.Username == Username).FirstOrDefault();
            return user;
        }

    }
}

