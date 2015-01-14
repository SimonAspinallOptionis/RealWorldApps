using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.RealWorldApps.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Gallery()
        {
            var data = new Data();
            data.AddImages();
            return View(data.Gallery);
        }

        public ActionResult Video()
        {
            return View();
        }
    }
}
