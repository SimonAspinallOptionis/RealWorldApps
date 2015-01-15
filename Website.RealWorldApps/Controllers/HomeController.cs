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
            Data.AddTeams("Under 13", "White");
            Data.AddNews();
            Data.AddImages();
            Data.AddLeagueTable("Under 13", "White");
            Data.AddGames("Under 13", "White");
            Data.AddSchedule("Under 13", "White");
            Data.AddCoaches("Under 13", "White");
            Data.AddPlayers("Under 13","White");
            ViewBag.Under13Fixture = Data.League.Teams[0].Schedule.Where(g => g.TipOff > DateTime.Now).OrderBy(g => g.TipOff).ToList()[0];
            ViewBag.Under13Result = Data.League.Teams[0].Results.Where(g => g.TipOff < DateTime.Now).OrderByDescending(g => g.TipOff).ToList()[0];

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
