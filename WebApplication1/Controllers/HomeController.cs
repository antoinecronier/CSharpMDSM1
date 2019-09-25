using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            using (WebApplication1Context db = new WebApplication1Context())
            {
                List<Class1> class1s = new List<Class1>();
                for (int i = 0; i < 5; i++)
                {
                    class1s.Add(new Class1() { Data = "data" + i });
                    db.Class1.Add(class1s.ElementAt(i));
                }
                db.SaveChanges();

                db.Class2.Add(new Class2() { Item1 = "test", Item2 = true, Item3 = DateTime.Now, Item4 = 20.20, Class1s= class1s});
                db.SaveChanges();
            }

            return View();
        }
    }
}