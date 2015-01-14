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

        public ActionResult LeagueTable()
        {
            var data = new Data();
            data.AddLeagueTable();
            data.LeagueTable = data.LeagueTable.OrderByDescending(t => t.Points).ThenBy(t => t.PointsDifference).ThenBy(t => t.PointsFor).ToList();
            return View(data.LeagueTable);
        }
    }
}
