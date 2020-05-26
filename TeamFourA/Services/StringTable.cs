using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Services
{
    public class StringTable
    {
        public string login { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public string user_not_found { get; set; }
        public string password_incorrect { get; set; }
        public string username_taken { get; set; }
        public string register { get; set; }
        public string all_fields_required { get; set; }
        public string unmatch_passwords { get; set; }
        public string welcome { get; set; }

        public string loginfail { get; set; }
    }
}
