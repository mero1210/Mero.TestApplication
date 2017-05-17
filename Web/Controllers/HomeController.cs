using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (MeroDBEntities context = new MeroDBEntities())
            {
                if (!context.Counters.Any())
                {
                    Counter counter = new Counter { count = 0 };
                    context.Counters.Add(counter);
                    context.SaveChanges();
                }
                else
                {
                    Counter counter = context.Counters.FirstOrDefault();
                    counter.count = 0;
                    context.SaveChanges();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Increment()
        {
            int count = 0;
            using (MeroDBEntities context = new MeroDBEntities())
            {
                Counter counter = context.Counters.FirstOrDefault();

                if (counter.count < 10)
                {
                    counter.count = counter.count + 1;
                    context.SaveChanges();
                }
                count = counter.count;
            }

            return Json(new { Counter = count });
        }
    }
}