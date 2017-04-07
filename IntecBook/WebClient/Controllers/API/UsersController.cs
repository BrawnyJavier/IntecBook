//using Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DataModel;
using WebClient.Services;
using Utilities;

//using Ximplit.WallApp.Services;

namespace Ximplit.WallApp.Controllers.API
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public bool Login(string credentials)
        {
            try
            {
                string[] Credentials = credentials.Split('|');
                string username = Credentials[0];
                string password = Credentials[1];
                using (var _context = new IntecBookContext())
                {
                    bool r = _context.Users.Any(user =>
                 user.username.Equals(username, StringComparison.OrdinalIgnoreCase)
                 && user.password == password
                 );
                    return r;
                }
            }
            catch (Exception) { return false; }
        }
        [HttpGet]
        public bool sendPassword(string username)
        {
            using (var context = new IntecBookContext())
            {
                User user = context.Users.Where(u => u.username == username).FirstOrDefault();
                if (user != null)
                {
                    var emailHandler = new EmailSender();
                    var Email = context.StoredEmails.Where(email => email.EmailCode == "PASSWORD").FirstOrDefault();
                    string EmailSubject = Email.Subject;
                    string EmailBody = Email.Body + " Usuario: " + user.username + " Contraseña: " + user.password;
                    emailHandler.SendEmail(EmailBody, EmailSubject, user.Email);
                    return true;
                }
                return false;
            }
        }
        [HttpGet]
        public IEnumerable<object> GetUsers()
        {
            using (var _context = new IntecBookContext())
            {
                // Return all but the password  x)
                return _context.Users.Select(s => new
                {
                    LastName = s.LastName,
                    Name = s.Name,
                    UserName = s.username,
                    Email = s.Email
                }).ToList();
            }
        }
        [HttpGet]
        public object GetUserByUsername(string userName)
        {
            using (var _context = new IntecBookContext())
            {
                return _context.Users.Where(u => u.username == userName).Select(
                    s => new
                    {
                        LastName = s.LastName,
                        Name = s.Name,
                        UserName = s.username,
                        Email = s.Email
                    }).FirstOrDefault();
            }
        }
        // POST: api/Users
        [HttpPost]
        public object CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                using (var _context = new IntecBookContext())
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    var emailHandler = new EmailSender();
                    var Email = _context.StoredEmails.Where(email => email.EmailCode == "WELCOME").FirstOrDefault();
                    string EmailBody = Email.Body;
                    string EmailSubject = Email.Subject + " " + user.Name + " " + user.LastName + "!";
                    emailHandler.SendEmail(EmailBody, EmailSubject, user.Email);
                }
                return HttpStatusCode.OK;
            }
            else return HttpStatusCode.BadRequest;
        }
        // PUT: api/Users/5        

        [BasicAuth]
        public object UpdateUser([FromBody]User value)
        {
            if (value.username.Equals(Thread.CurrentPrincipal.Identity.Name, StringComparison.OrdinalIgnoreCase))
            {
                using (var contex = new IntecBookContext())
                {
                    var userInDatabase = contex.Users.Where(u => u.username == value.username).FirstOrDefault();
                    userInDatabase.LastName = value.LastName;
                    userInDatabase.Name = value.Name;
                    userInDatabase.password = value.password;
                    userInDatabase.username = value.username;
                    userInDatabase.Email = value.Email;
                    contex.SaveChanges();
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.Unauthorized;
        }
        // DELETE: api/Users/5
        [HttpDelete]
        [BasicAuth]
        public object DeleteUser(string username)
        {
            using (var context = new IntecBookContext())
            {
                // confirm if the current user is the owner of the account
                bool isUser = username == Thread.CurrentPrincipal.Identity.Name;
                if (isUser) // Only the owner of the account can delete it.
                {
                    var toDelete = context.Users.Where(u => u.username == username).FirstOrDefault();
                    context.Users.Remove(toDelete);
                    return HttpStatusCode.OK;
                }
                else return HttpStatusCode.Unauthorized;
            }
        }
    }
}
