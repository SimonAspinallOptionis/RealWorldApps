using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            var data = new Data();
            data.AddNews();
            return View(data.News);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
