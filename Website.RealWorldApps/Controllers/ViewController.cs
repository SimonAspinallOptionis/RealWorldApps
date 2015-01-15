using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.RealWorldApps.Controllers
{
    public class ViewController : Controller
    {
        private Data _data = HomeController.Data;

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult LeagueTable()
        {
            _data.LeagueTable = _data.LeagueTable.OrderByDescending(t => t.Points).ThenBy(t => t.PointsDifference).ThenBy(t => t.PointsFor).ToList();
            return View(_data.LeagueTable);
        }
    }
}
