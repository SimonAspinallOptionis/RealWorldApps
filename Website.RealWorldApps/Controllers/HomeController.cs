using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var news = new List<News>();
            news.Add(new News { Headline = "Welcome", Body = "Welcome to Real World Apps" });
            news.Add(new News { Headline = "Ahh", Body = "Something crazy just happened" });
            return View(news);
        }

    }
}
