using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Services
{
    public class StringTable_en : StringTable
    {
        public StringTable_en()
        {
            login = "Login";
            username = "Username";
            password = "Password";
            confirm_password = "Confirm Password";
            user_not_found = "User is not found.";
            loginfail = "Username or Password is incorrect.";
            password_incorrect = "Password is incorrect.";
            username_taken = "Username already taken.";
            register = "Register";
            all_fields_required = "All fields are required.";
            unmatch_passwords = "Passwords do not match.";
            welcome = "Welcome!";
        }
    }
}
