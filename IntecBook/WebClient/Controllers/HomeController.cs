using IntecBook.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var _context = new IntecBookContext())
            {
                _context.Day.Add(new IntecBook.classes.Day()
                {
                    Id = 2,
                    Name = "Lunes"
                });
                _context.SaveChanges();
            }
            return View();
        }
    }
}
