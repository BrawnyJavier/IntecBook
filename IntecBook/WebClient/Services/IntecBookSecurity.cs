using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntecBook.DataModel;
using IntecBook.classes;

namespace WebClient.Services
{
    public class IntecBookSecurity
    {
        public static bool Login(string username, string password)
        {
            using (var _context = new IntecBookContext())
            {

                return _context.Users.Any(user =>
                 user.username.Equals(username, StringComparison.OrdinalIgnoreCase)
                 && user.password == password
                 );

            }
        }
    }
}