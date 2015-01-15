using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;
using System;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        public static Data Data { get; set; }

        public ActionResult Home()
        {
            Data = new Data();
            Data.AddLeagues();
            Data.AddNews();
            Data.AddImages();
            Data.AddLeagueTable("Under 13");
            Data.AddGames("Under 13");
            Data.AddSchedule("Under 13");
            Data.AddCoaches("Under 13");
            Data.AddPlayers("Under 13");
            ViewBag.Under13Fixture = Data.League.Team.Schedule.Where(g => g.TipOff > DateTime.Now).OrderBy(g => g.TipOff).ToList()[0];
            ViewBag.Under13Result = Data.League.Team.Results.Where(g => g.TipOff < DateTime.Now).OrderByDescending(g => g.TipOff).ToList()[0];

            return View(Data.News);
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
