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
                var Days = new List<IntecBook.classes.Day>();
                string[] WeekDays = { "Lunes","Martes", "Miercoles",
                                    "Jueves", "Viernes", "Sabado"  };
                for (int i = 0; i < 6; i++)
                {
                    Days.Add(new IntecBook.classes.Day
                    {
                        Name = WeekDays[i]
                    });
                }
                _context.Day.AddRange(Days);
                _context.SaveChanges();
            }
            return View();
        }
    }
}
